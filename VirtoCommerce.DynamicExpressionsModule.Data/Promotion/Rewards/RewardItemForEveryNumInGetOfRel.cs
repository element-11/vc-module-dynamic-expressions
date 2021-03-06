using VirtoCommerce.Domain.Common;
using VirtoCommerce.Domain.Marketing.Model;

namespace VirtoCommerce.DynamicExpressionsModule.Data.Promotion
{
    //For [] in every [] items of entry [] get [] % off no more than [] not to exceed $ []
    public class RewardItemForEveryNumInGetOfRel : DynamicExpression, IRewardExpression
    {
        public decimal Amount { get; set; }
        public ProductContainer Product { get; set; } = new ProductContainer();
        public int ForNthQuantity { get; set; }
        public int InEveryNthQuantity { get; set; }
        public int ItemLimit { get; set; }
        public decimal MaxLimit { get; set; }

        #region IRewardExpression Members

        public virtual PromotionReward[] GetRewards()
        {
            var retVal = new CatalogItemAmountReward
            {
                Amount = Amount,
                AmountType = RewardAmountType.Relative,
                Quantity = ItemLimit,
                ForNthQuantity = ForNthQuantity,
                InEveryNthQuantity = InEveryNthQuantity,
                ProductId = Product?.ProductId,
                MaxLimit = MaxLimit,
            };
            return new PromotionReward[] { retVal };
        }

        #endregion
    }
}
