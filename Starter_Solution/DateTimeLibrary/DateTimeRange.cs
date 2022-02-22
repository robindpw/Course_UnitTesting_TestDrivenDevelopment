using System;

namespace DateTimeLibrary
{
    public struct DateTimeRange
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public DateTimeRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("Start date should not be later than end date.");
            _startDate = startDate;
            _endDate = endDate;
        }

        public bool Includes(DateTime dateTime)
        {
            return dateTime >= _startDate
                   && dateTime <= _endDate;
        }
    }
}