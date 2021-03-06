using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.Domain.Common;

namespace VirtoCommerce.DynamicExpressionsModule.Data.Promotion
{
    //Get [] % off shipping [] not to exceed $ [ 500 ]
    public class RewardShippingGetOfRelShippingMethod : DynamicExpression, IRewardExpression
	{
		public decimal Amount { get; set; }
		public string ShippingMethod { get; set; }
	    public decimal MaxLimit { get; set; }

        #region IRewardExpression Members

        public PromotionReward[] GetRewards()
		{
			var retVal = new ShipmentReward
			{
				Amount = Amount,
				AmountType = RewardAmountType.Relative,
				ShippingMethod = ShippingMethod,
                MaxLimit = MaxLimit
			};
			return new PromotionReward[] { retVal };
		}

		#endregion
	}
}
