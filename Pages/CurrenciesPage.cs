﻿using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages
{
    public class CurrenciesPage : BasePage<CurrencyView, Currency, ICurrencyRepo>  {
        public CurrenciesPage(ICurrencyRepo r) : base(r) { }
        protected override Currency toObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView toView(Currency? entity) => new CurrencyViewFactory().Create(entity);
    }
}
