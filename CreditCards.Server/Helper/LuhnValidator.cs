using CreditCards.Server.Helper.Interfaces;

namespace CreditCards.Server.Helper
{
    public class LuhnValidator : ILuhnValidator
    {
        public bool IsValidCard(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber) || !cardNumber.All(char.IsDigit) )
                return false;

            int cardlength = cardNumber.Length;
            int currentNumber;
            int sum = 0;
            bool isSecond = false;
            for (int i = cardlength - 1; i >= 0; i--)
            {
                currentNumber = int.Parse(cardNumber[i].ToString());
                int d;

                if (isSecond == true)
                {
                    int doubleling = currentNumber * 2;
                    d = doubleling > 9 ? doubleling - 9 : doubleling;
                }
                else 
                {
                    d = currentNumber; 
                }

                sum += d;
                isSecond = !isSecond;
            }
            return sum % 10 == 0;
        }
    }
}
