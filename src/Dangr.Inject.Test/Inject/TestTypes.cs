// -----------------------------------------------------------------------
//  <copyright file="TestTypes.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
// -----------------------------------------------------------------------

namespace Dangr.Inject
{
    public class TestTypes
    {
        public interface IClass1
        {
        }

        public interface IClass2
        {
        }

        public class Class1 : IClass1
        {
        }

        public class Class2 : IClass2
        {
        }

        public class Class3
        {
        }

        public class Class1Container
        {
            public readonly IClass1 Class1Instance;

            [Inject]
            public Class1Container(IClass1 class1Instance)
            {
                this.Class1Instance = class1Instance;
            }
        }

        public class LoopedClass1
        {
            [Inject]
            public LoopedClass1(LoopedClass2 lc2)
            {
            }
        }

        public class LoopedClass2
        {
            [Inject]
            public LoopedClass2(LoopedClass1 lc2)
            {
            }
        }

        public interface ISetClass
        {
        }

        public class SetClass1 : ISetClass
        {
        }

        public class SetClass2 : ISetClass
        {
        }

        public class SetClass3 : ISetClass
        {
            public static int Id;

            public int InstanceId { get; }

            public SetClass3()
            {
                this.InstanceId = SetClass3.Id++;
            }
        }
    }
}