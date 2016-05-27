﻿namespace Lecture8
{
    using System;

    public class Bank
    {
        public void Transaction(AccountBase sender, AccountBase recipient, double sum)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"Переданое значение NULL", nameof(sender));
            }

            if (recipient == null)
            {
                throw new ArgumentNullException($"Переданое значение NULL", nameof(recipient));
            }

            sender.WithdrawFunds(sum);
            recipient.AddFunds(sum);
        }
    }
}
