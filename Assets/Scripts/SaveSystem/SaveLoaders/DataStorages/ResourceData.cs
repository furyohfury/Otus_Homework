﻿namespace SaveLoadHomework.SaveLoaders.DataStorage
{
    public struct ResourceData
    {
        public int ID;

        public int Amount;

        public ResourceData(int amount, int iD)
        {
            Amount = amount;
            ID = iD;
        }
    }
}