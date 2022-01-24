# Course UnitTesting and TestDrivenDevelopment
Course material for the unit testing &amp; test driven development course. @Inetum-realdolmen 2022

[![Maintenance](https://img.shields.io/badge/Maintained%3F-no-red.svg)](https://github.com/robindpw/Course_UnitTesting_TestDrivenDevelopment)
[![Github last commit](https://img.shields.io/github/last-commit/robindpw/Course_UnitTesting_TestDrivenDevelopment)]()
![](https://komarev.com/ghpvc/?username=robindpw)
[![](https://img.shields.io/badge/Click%20me%20for%20sollutions-blue.svg)](https://github.com/robindpw/Course_UnitTesting_TestDrivenDevelopment/tree/solutions)

## Exercises

### 1.1 Basic Calculator Exercise
#### 1.1. Create a Calculator class with these methods:
```
  -> Add(int x, int y)
  -> Subtract(int x, int y)
  -> Multiply(int x, int y)
  -> Divide(int x, int y)
```

#### 1.1.1. Create these tests for Add:
```
  -> 1 + 0 = 1
  -> -5 + 10 = 5
  -> 0 + 1 = 1
  -> Create tests with the same operands as the previous one, but for the other operations
```

#### 1.1.2 Implement the asserts from the previous tests using the library FluentAssertions

#### 1.1.3 Parametrize the previous unit tests using Theory and InlineData

#### 1.1.4 We've received a bug, write a test for this case:
    2147483647 + 1 = 2147483648

### 1.2 DateTimeRange
```
  Create a struct DateTimeRange. 
  A DateTimeRange is constructed using two properties: Begin and End.
  DateTimeRanges are not equal if Begin and/or End are not equal.
  DateTimeRange has one method: IsInRange(DateTime dateTime),
  that will determine if the given date time is in its range.

  You can use FluentAssertions and/or Theories. DateTime cannot be passed
  as an argument to InlineData, so you will have to use MemberData
  ```
### 1.3 StringMixer
```
  Write the code and tests for a method that takes two strings and returns expected:
  "abc", "def" => "adbecf"
  "ab", "def" => "adbef"
  "abc", "de" => "adbec"
  "", "def" => "def"
  "abc", "" => "abc"
```

### 2.1 Restaurant
```
  We're responsible for writing the software for a restaurant.
  In a class Restaurant, we can place and serve orders. 
  This class has a dependency on an IKitchen. 
  An order has a TableNumber and a TotalPrice.
  A table can have multiple orders on one night.
  At the end of the night, we want to be able to retrieve statistics for the tables and orders
  that have been placed. We want to see this:
  - The table with the highest sum of all TotalPrices for that table
  - The table with the most orders
  - The avarage TotalPrice
  The Kitchen can return all placed orders through: GetAllOrders()
  Please write code and unit tests for this class
```

### 2.2 ShoppingBasket
```
  We will create a Smart ShoppingBasket.
  The basket registers article id and weight when an item is added.
  The basket has a display that shows the total amount and price of its contents.
  This price is calculated by an external service, 
  as there can be updates at any given moment.
  We are required by law to only allow recalculation if the price of an item is lowered.
  that returns the amount, name and price of each article in the basket
  as there might be new updates at any given moment.
  It also has an integrated sound module 
  that notifies the user of updates or when the weight is exceeded


  Scenario: We add an item to an empty basket
  Given we have an empty Shopping Basket
  And there is an item in the catalog: articleId: 1, name: "12 Eggs", price: 2.69 Euros 
  When we add an item with Article Id 1
  Then the Display shows: "1 x 12 Eggs, 2.69 Euro; Total Amount: 2.69 Euro"

  Scenario: A lower price update has been pushed
  Given we have shopping basket with these contents:
  | ArticleId	| Amount	|
  | 1			| 2			|
  | 2			| 5			|
  And the catalog contains these articles:
  | ArticleId	| Name		| Price	|
  | 1			| 12 Eggs	| 2.69	|
  | 2			| 1l Water	| 1.5	|
  When there is a price update for articleId: 1 => 2.20 Euros
  Then the Display shows: "2 x 12 Eggs, 4.40 Euro; 5 x 1l Water, 7.50 Euro; Total Amount: 11.90 Euro"
  And the sound module beeps

  Scenario: A higher price update has been pushed
  Given we have shopping basket with these contents:
  | ArticleId	| Amount	|
  | 1			| 2			|
  | 2			| 5			|
  And the catalog contains these articles:
  | ArticleId	| Name		| Price	|
  | 1			| 12 Eggs	| 2.69	|
  | 2			| 1l Water	| 1.5	|
  When there is a price update for articleId: 1 => 3.20 Euros
  Then the Display shows: "2 x 12 Eggs, 5.38 Euro; 5 x 1l Water, 7.50 Euro; Total Amount: 12.88 Euro"
  And the sound module does not beep

  Scenario: The allowed weight is exceeded
  Given we have an empty Shopping Basket with allowed weight: 0.75kg
  When we add an item with weight 1kg
  Then the Display shows: "Allowed weight exceeded, please remove one or more articles."
  And the sound module beeps three times
```
