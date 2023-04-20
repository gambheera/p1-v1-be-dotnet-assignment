using System;
using System.Collections.Generic;
using Domain.SeedWork;

namespace Domain.Common
{
    public class Price : ValueObject
    {
        public decimal Value { get; private set; }
        public Currency Currency { get; private set; }

        protected Price()
        {
        }

        public Price(decimal value, Currency currency)
        {
            Value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
            Currency = currency;
        }

        public string GetCurrencyCode()
        {
            string currencyCode = "EUR";

            // TODO: Write a proper way to fetch currency code via an API to get standerd currency code.

            switch (Currency)
            {
                case Currency.USD:
                    currencyCode = "EUR";
                    break;
                case Currency.AUD:
                    currencyCode = "EUR";
                    break;
                default:
                    break;
            }

            return currencyCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}