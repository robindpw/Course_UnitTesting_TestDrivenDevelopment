using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Shopping
{
    public class ShoppingBasket
    {
        private const string CurrencyFormat = "0.00";
        private static CultureInfo CurrencyCultureInfo = new CultureInfo("en-US");

        private readonly List<ArticleEntry> _innerArticles = new List<ArticleEntry>();
        private readonly ISoundModule _soundModule;
        private readonly IPriceCatalog _priceCatalog;
        private readonly float _allowedWeight;
        private float _currentWeight;

        public ShoppingBasket(ISoundModule soundModule, IPriceCatalog priceCatalog, float allowedWeight)
        {
            _soundModule = soundModule;
            _priceCatalog = priceCatalog;
            _allowedWeight = allowedWeight;
        }

        public ShoppingBasket(ISoundModule soundModule, IPriceCatalog priceCatalog, float allowedWeight, ArticleEntry[] articles)
            : this(soundModule, priceCatalog, allowedWeight)
        {
            _innerArticles = articles.ToList();
        }

        public void AddArticle(int id, float weight)
        {
            Article article = _priceCatalog.GetArticle(id);

            _innerArticles.Add(new ArticleEntry()
            {
                ArticleId = article.Id,
                UnitPrice = article.Price,
                Name = article.Name
            });
            _currentWeight += weight;
            if (_currentWeight > _allowedWeight)
                Beep(3);
        }

        public string Display
        {
            get
            {
                if (_currentWeight > _allowedWeight)
                    return "Allowed weight exceeded, please remove one or more articles.";

                var result = new StringBuilder();
                decimal sumTotalPrice = 0m;
                foreach (var ae in _innerArticles)
                {
                    sumTotalPrice += ae.TotalPrice;
                    result.Append($"{ae.Count} x {ae.Name}, {ae.TotalPrice.ToString(CurrencyFormat, CurrencyCultureInfo)} Euro; ");
                }
                result.Append($"Total Amount: {sumTotalPrice.ToString(CurrencyFormat, CurrencyCultureInfo)} Euro");

                return result.ToString();
            }
        }

        public void UpdatePrices()
        {
            bool shouldBeep = false;
            foreach (var ae in _innerArticles)
            {
                Article article = _priceCatalog.GetArticle(ae.ArticleId);
                if (article.Price < ae.UnitPrice)
                {
                    ae.UnitPrice = article.Price;
                    shouldBeep = true;
                }
            }
            if (shouldBeep)
                Beep();
        }

        private void Beep(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                _soundModule.Beep();
            }
        }
    }
}