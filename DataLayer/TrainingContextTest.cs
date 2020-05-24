using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class TrainingContextTest : TrainingContext
    {
        public TrainingContextTest() : base("Test")
        {

        }
        public TrainingContextTest(bool keepExistingDB = false) : base("Test")
        {
            if (keepExistingDB)
                Database.EnsureCreated();
            else{
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
    }
}
