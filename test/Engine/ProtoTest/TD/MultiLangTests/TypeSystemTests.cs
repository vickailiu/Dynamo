using NUnit.Framework;
using ProtoCore.DSASM.Mirror;
using ProtoTestFx.TD;
namespace ProtoTest.TD.MultiLangTests
{
    [TestFixture]
    class TypeSystemTests
    {
        readonly TestFrameWork thisTest = new TestFrameWork();
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [Category("Type System")]
        public void TS001_IntToDoubleTypeConversion()
        {
            string code =
                @"a = 1;
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 1);
            thisTest.Verify("b", 1.0);
        }

        [Test]
        [Category("Type System")]
        public void TS001a_DoubleToIntTypeConversion()
        {
            string code =
                @"a = 1.0;
            thisTest.RunScriptSource(code);
            //These should convert and emit warnings
            thisTest.Verify("a", 1.0);
            thisTest.Verify("b", 1);
            thisTest.Verify("c", 2);
            thisTest.Verify("d", 3);
            thisTest.Verify("e", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS002_IntToUserDefinedTypeConversion()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 1);
            thisTest.Verify("b", null);
        }

        [Test]
        [Category("Type System")]
        public void TS003IntToChar1467119()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("y", null);
            TestFrameWork.VerifyRuntimeWarning(ProtoCore.RuntimeData.WarningID.kMethodResolutionFailure);
        }

        [Test]
        [Category("Type System")]
        public void TS004_IntToChar_1467119_2()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("y", true);
        }

        [Test]
        [Category("Type System")]
        public void TS005_RetTypeArray_return_Singleton_1467196()
        {
            string code =
                @"
            //Assert.Fail("1467196 - Sprint 25 - Rev 3216 - [Design Issue] when rank of return type does not match the value returned what is the expected result ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 0 });
        }

        [Test]
        [Category("Type System")]
        public void TS005_RetTypeArray_return_Singleton_1467196_a()
        {
            string code =
                @"
            //Assert.Fail("1467196 - Sprint 25 - Rev 3216 - [Design Issue] when rank of return type does not match the value returned what is the expected result ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS005_RetTypeArray_return_Singleton_1467196_b()
        {
            string code =
                @"
            //Assert.Fail("1467196 - Sprint 25 - Rev 3216 - [Design Issue] when rank of return type does not match the value returned what is the expected result ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 0 });
        }


        [Test]
        [Category("Type System")]
        public void TS006_RetTypeuserdefinedArray_return_double_1467196()
        {
            string code =
                @"
            //Assert.Fail("1467196 - Sprint 25 - Rev 3216 - [Design Issue] when rank of return type does not match the value returned what is the expected result ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            //thisTest.Verify("a",); not sure what is the expected behaviour 
        }

        [Test]
        [Category("Type System")]
        public void TS007_Return_double_To_int_1467196()
        {
            string code =
                @"
            //Assert.Fail("1467196 - Sprint 25 - Rev 3216 - [Design Issue] when rank of return type does not match the value returned what is the expected result ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("numpts", 1.0);
            thisTest.Verify("a", null);
        }

        [Test]
        [Category("Type System")]
        public void TS008_Param_Int_IntArray_1467208()
        {
            string code =
                @"
            string error = "DNL-1467208 Auto-upcasting of int -> int[] is not happening in some cases";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("r", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS009_Parameter_Int_ToBoolArray_1467182()
        {
            string code =
                @"
            //int -> bool -> bool array
            string error = "1467303 -Sprint 26 - Rev 3779 - int to bool array conversion does not happen for function arguments ";

            thisTest.RunScriptSource(code, error);
            thisTest.Verify("r", new object[] { true });

        }

        [Test]
        [Category("Type System")]
        public void TS010_Parameter_Bool_ToIntArray_1467182()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TS011_Return_Int_ToIntArray()
        {
            string code =
                @"
            //Assert.Fail("1467200 - Sprint 25 - rev 3242 type checking negative cases failing ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", new object[] { 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS012_Return_Int_ToBoolArray_1467182()
        {
            string code =
                @"
            //Assert.Fail("1467182 - Sprint 25 - [Design Decision] Rev 3163 - method resolution or type conversion is expected in following cases  ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TS013_Parameter_Bool_ToIntArray()
        {
            string code =
                @"
            //Assert.Fail("1467200 - Sprint 25 - rev 3242 type checking negative cases failing ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TS014_Return_IntArray_ToInt()
        {
            string code =
                @"
            //Assert.Fail("1467200 - Sprint 25 - rev 3242 type checking negative cases failing ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TS015_Parameter_BoolArray_ToInt()
        {
            string code =
                @"
            //Assert.Fail("1467200 - Sprint 25 - rev 3242 type checking negative cases failing ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TS016_Return_BoolArray_ToInt()
        {
            string code =
                @"
            //Assert.Fail("1467200 - Sprint 25 - rev 3242 type checking negative cases failing ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TS017_Return_BoolArray_ToInt_1467182()
        {
            string code =
                @"
            string error = "1467182 - Sprint 25 - [Design Decision] Rev 3163 - method resolution or type conversion is expected in following cases ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("c", null);// null 
        }

        [Test]
        [Category("Type System")]
        public void TS018_Param_Int_ordouble_ToBool_1467172()
        {
            string code =
                @"
            //Assert.Fail("1467172 - sprint 25 - Rev 3146 - [Design Issue ] the type conversion between int/double to bool not allowed ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("b", new object[] { true });
            thisTest.Verify("c", new object[] { true });
            thisTest.Verify("d", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS018_Return_Int_ordouble_ToBool_1467172_2()
        {
            string code =
                @"
            //Assert.Fail("1467172 - sprint 25 - Rev 3146 - [Design Issue ] the type conversion between int/double to bool not allowed ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("b", true);
            thisTest.Verify("c", true);
            thisTest.Verify("d", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS019_conditional_cantevaluate_1467170()
        {
            string code =
                @"A;
            thisTest.RunScriptSource(code);
            thisTest.Verify("A", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS019_conditional_cantevaluate_1465293_2()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("A", 2);
        }

        [Test]
        [Category("Type System")]
        public void TS019_conditional_cantevaluate_1465293_3()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("test1", false);
            thisTest.Verify("test2", true);
            thisTest.Verify("test3", false);
        }

        [Test]
        [Category("Type System")]
        public void TS020_conditional_cantevaluate_1467170()
        {
            string code =
                @"A;
            thisTest.RunScriptSource(code);
            thisTest.Verify("A", 2);
        }

        [Test]
        [Category("Type System")]
        public void TS020_conditional_cantevaluate_1465293()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("z", new object[] { 1, 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS020_conditional_cantevaluate_1465293_2()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("z", new object[] { 1, 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS020_conditional_cantevaluate_1465293_3()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("z", new object[] { 1, 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS020_conditional_cantevaluate_1465293_4()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("z", new object[] { 1, 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS021_OverallPrimitiveConversionTestInt()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("zero_var", 0);
            thisTest.Verify("zero_int", 0);
            thisTest.Verify("zero_double", 0.0);
            thisTest.Verify("zero_bool", false);
            thisTest.Verify("zero_String", null);
            thisTest.Verify("zero_char", null);
            thisTest.Verify("zero_a", null);
            thisTest.Verify("one_var", 1);
            thisTest.Verify("one_int", 1);
            thisTest.Verify("one_double", 1.0);
            thisTest.Verify("one_bool", true);
            thisTest.Verify("one_String", null);
            thisTest.Verify("one_char", null);
            thisTest.Verify("one_a", null);
            thisTest.Verify("foo", 32);
            thisTest.Verify("foo2", 33);
            thisTest.Verify("foo3", 33);
        }

        [Test]
        [Category("Type System")]
        public void TS022_conditional_cantevaluate_1467170()
        {
            string code =
                @"A;
            thisTest.RunScriptSource(code);
            thisTest.Verify("A", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS022_conditional_cantevaluate_1465293()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("A", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS022_conditional_cantevaluate_1465293_3()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("b", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS023_Double_To_Int_1467084()
        {
            string code =
                @"
            //Assert.Fail("1463268 - Sprint 20 : [Design Issue] Rev 1822 : Method resolution fails when implicit type conversion of double to int is expected ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("x", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS023_Double_To_Int_1467084_2()
        {
            string code =
                @"
            //Assert.Fail("1463268 - Sprint 20 : [Design Issue] Rev 1822 : Method resolution fails when implicit type conversion of double to int is expected ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("t", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS023_Double_To_Int_1467084_3()
        {
            string code =
                @"
            //Assert.Fail("1463268 - Sprint 20 : [Design Issue] Rev 1822 : Method resolution fails when implicit type conversion of double to int is expected ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("d", new object[] { null, null });
        }

        [Test]
        [Category("Type System")]
        public void TS024_Double_To_Int_IndexIntoArray_1467214()
        {
            string code =
                @"
            //     Assert.Fail("1467214 - Sprint 26- Rev 3313 Type Conversion from Double to Int not happening while indexing into array ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("b", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS025_KeyWords_Doesnotexist_1467215()
        {
            string code =
                @"
            string error = "1467215 - Sprint 26 - rev 3310 language is too easy on key words for typesystem , even when does not exist it passes  ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
        }

        [Test]
        [Category("Type System")]
        public void TS026_Double_ToInt_1467211()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS027_Double_ToInt_1467217()
        {
            string code =
                @"
            //Assert.Fail("1467217 - Sprint 26 - Rev 3337 - Type Conversion does not happen if the function returns an array ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 4 });
        }

        [Test]
        [Category("Type System")]
        public void TS028_Double_ToInt_1467218()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS028_Double_ToInt_1467218_1()
        {
            string code =
                @"
            //Assert.Fail("1467218 - Sprint 26 - Rev 3337 - Type Conversion does not happen if the function returns and array and and index into function call ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS029_Double_ToVar_1467222()
        {
            string code =
                @"
            //Assert.Fail("1467222 - Sprint 26 - rev 3345 - if return type is var it still does type conversion ");
            thisTest.RunScriptSource(code);
            thisTest.Verify("b", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS029_Double_ToInt_1463268()
        {
            string code =
                @"
            //Assert.Fail("1463268 - Sprint 20 : [Design Issue] Rev 1822 : Method resolution fails when implicit type conversion of double to int is expected");
            thisTest.RunScriptSource(code);
            thisTest.Verify("t", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS030_eachtype_To_var()
        {
            string code =
                @"class A{ a=1; }
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 1.5);
            thisTest.Verify("b", 1);
            thisTest.Verify("c", "1.5");
            thisTest.Verify("d1", 1);
            thisTest.Verify("e", false);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS030_eachtype_To_var_2()
        {
            string code =
                @"class A{ a=1; }
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 1.5);
            thisTest.Verify("b", 1);
            thisTest.Verify("c", "1.5");
            thisTest.Verify("d1", 1);
            thisTest.Verify("e", false);
            thisTest.Verify("f", null);
        }


        [Test]
        [Category("Type System")]
        public void TS031_eachType_To_int()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 2);
            thisTest.Verify("b", 1);
            thisTest.Verify("c", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS031_null_To_int()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("f", 1);

        }

        [Test]
        [Category("Type System")]
        public void TS031_eachtype_To_double()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 1.0);
            thisTest.Verify("b", 1.0);
            thisTest.Verify("c", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS031_null_To_double()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("f", 1.0);
        }

        [Test]
        [Category("Type System")]
        public void TS032_null_To_bool()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("f", true);
        }

        [Test]
        [Category("Type System")]
        public void TS032_eachType_To_bool()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", true);
            thisTest.Verify("b", true);
            thisTest.Verify("c", true);
            thisTest.Verify("c1", false);
            thisTest.Verify("d", true);
            thisTest.Verify("e", true);
            thisTest.Verify("e1", null);
        }

        [Test]
        [Category("Type System")]
        public void TS033_eachType_To_string()
        {
            string code =
                @"
            string error = "1467311 - Sprint 26 - Rev 3788 - Char to String conversion not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", "1.5");
            thisTest.Verify("c1", "1");
            thisTest.Verify("d1", null);
            //   thisTest.Verify("c1", "1");//Assert.Fail("1467227 -Sprint 26 - 3329 char not convertible to string ");
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS033_null_To_string()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("f", "test");
        }

        [Test]
        [Category("Type System")]
        public void TS033_null_To_char()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("f", 'c');
        }

        [Test]
        [Category("Type System")]
        public void TS034_eachType_To_char()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("c1", '1');
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS34_CharToString_1467227()
        {
            string code =
               @"
            thisTest.RunScriptSource(code, "1467227 -Sprint 26 - 3329 char not convertible to string ");
            thisTest.Verify("a", "1");
        }

        [Test]
        [Category("Type System")]
        public void TS35_nullTobool_1467231()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            //Assert.Fail("1467231 - Sprint 26 - Rev 3393 null to bool conversion should not be allowed ");
            thisTest.Verify("a", null);
        }

        [Test]
        [Category("Type System")]
        public void TS36_stringTobool_1467239()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            //Assert.Fail("1467239 - Sprint 26 - Rev 3425 type conversion - string to bool conversion failing  ");
            thisTest.Verify("c", true);
            thisTest.Verify("c1", false);
        }

        [Test]
        [Category("Type System")]
        public void TS37_userdefinedTobool_1467240()
        {
            string code =
                @"
            string error = "1467240 - Sprint 26 - Rev 3426 user defined type not convertible to bool";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("d", true);
        }

        [Test]
        [Category("Type System")]
        public void TS37_userdefinedTo_null()
        {
            string code =
                @"

            thisTest.RunScriptSource(code);
            //Assert.Fail("1467240 - Sprint 26 - Rev 3426 user defined type not convertible to bool");
            thisTest.Verify("d1", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS038_eachType_To_Userdefined()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", 1);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS038_Param_single_AlltypeTo_UserDefined()
        {
            string code =
                @"
            string error = "1467314 - Sprint 26 - Rev 3805 user defined type to array of user defined type does not upgrade to array ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("d1", 2);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }


        [Test]
        [Category("Type System")]
        public void TS038_return_single_AlltypeTo_UserDefined()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("d1", 2);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS039_userdefined_covariance()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a1", 1);
            thisTest.Verify("b1", 2);
            thisTest.Verify("b2", 0);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("c2", null);
        }

        [Test]
        [Category("Type System")]
        public void TS039_userdefined_covariance_2()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a1", 1);
            thisTest.Verify("b1", 2);
            thisTest.Verify("b2", 2);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("c2", null);
        }

        [Test]
        [Category("Type System")]
        public void TS40_null_toBool_1467231()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
        }

        [Test]
        [Category("Type System")]
        public void TS41_null_toBool_1467231_2()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            thisTest.Verify("c", null);
        }

        [Test]
        [Category("Type System")]
        public void TS42_null_toBool_1467231_3()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("c", null);
        }

        [Test]
        [Category("Type System")]
        public void TS43_null_toBool_1467231_positive()
        {
            string code =
                @"b;
            thisTest.RunScriptSource(code);
            thisTest.Verify("b", 2);
        }

        [Test]
        [Category("Type System")]
        public void TS44_any_toNull()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS45_int_To_Double_1463268()
        {
            string code =
                @"

            thisTest.RunScriptSource(code);
            thisTest.Verify("t", 3);
            thisTest.Verify("t1", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_array_1467206()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 1.0, 2.0, 3.0 });
            thisTest.Verify("b", new object[] { 1, 2, 3 });
            thisTest.Verify("c", new object[] { "a", "b", "c" });
            thisTest.Verify("d", new object[] { 'c', 'd', 'e' });
            thisTest.Verify("e1", new object[] { 1, 1, 1 });
            thisTest.Verify("f", new object[] { true, false, null });
            thisTest.Verify("g", new object[] { null, null, null });
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_array_1467294_2()
        {
            string code =
                @"
            string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.0 });
            thisTest.Verify("b", new object[] { 1 });
            thisTest.Verify("c", new object[] { "a" });
            thisTest.Verify("d", new object[] { 'c' });
            thisTest.Verify("e1", new object[] { 1 });
            thisTest.Verify("f", new object[] { true });
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_array_1467294_3()
        {
            string code =
                @"
            // string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            string error = "1467332 Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { new object[] { 1.0 } });
            thisTest.Verify("b", new object[] { new object[] { 1 } });
            thisTest.Verify("c", new object[] { new object[] { "a" } });
            thisTest.Verify("d", new object[] { new object[] { 'c' } });
            thisTest.Verify("e1", new object[] { new object[] { 1 } });
            thisTest.Verify("f", new object[] { new object[] { true } });
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_Vararray_1467294_4()
        {
            string code =
                @"
            string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { new object[] { 1 } });
            thisTest.Verify("b", new object[] { new object[] { 1.1 } });
            thisTest.Verify("c", new object[] { new object[] { "a" } });
            thisTest.Verify("d", new object[] { new object[] { 'c' } });
            thisTest.Verify("e1", new object[] { new object[] { 1 } });
            thisTest.Verify("f", new object[] { new object[] { true } });
            thisTest.Verify("g", new object[] { new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_Intarray()
        {
            string code =
                @"
            string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1 });
            thisTest.Verify("b", new object[] { 1 });
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]

        [Category("Type System")]
        public void TS46_typedassignment_singleton_To_Intarray()
        {
            string code =
                @"
            //string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            string error = "1467332  - Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { new object[] { 1 } });
            thisTest.Verify("b", new object[] { new object[] { 1 } });
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]

        [Category("Type System")]
        public void TS46_typedassignment_To_doublearray()
        {
            string code =
                @"
            //string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            string error = "1467332  - Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.0 });
            thisTest.Verify("b", new object[] { 1.1 });
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_Singleton_To_doublearray()
        {
            string code =
                @"
            //            string error = "Design issue - Validation required for failures- should it be null or {null}";
            string error = "1467332  - Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { new object[] { 1.0 } });
            thisTest.Verify("b", new object[] { new object[] { 1.1 } });
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_boolarray()
        {
            string code =
                @"
            string error = "1467295- Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";

            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true });
            thisTest.Verify("b", new object[] { true });
            thisTest.Verify("c", new object[] { true });
            thisTest.Verify("d", new object[] { true });
            thisTest.Verify("e", new object[] { true });
            thisTest.Verify("f", new object[] { true });
            thisTest.Verify("g", null);
        }

        [Test]

        [Category("Type System")]
        public void TS46_typedassignment_singleton_To_boolarray()
        {
            string code =
                @"
            //string error = "1467295- Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            string error = "1467332  - Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { new object[] { true } });
            thisTest.Verify("b", new object[] { new object[] { true } });
            thisTest.Verify("c", new object[] { new object[] { true } });
            thisTest.Verify("d", new object[] { new object[] { true } });
            thisTest.Verify("e", new object[] { new object[] { true } });
            thisTest.Verify("f", new object[] { new object[] { true } });
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_boolarray_2()
        {
            string code =
                @"
            string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { false });
            thisTest.Verify("b", new object[] { false });
            thisTest.Verify("c", new object[] { false });
            thisTest.Verify("d", new object[] { false });
            thisTest.Verify("e1", new object[] { false });
            thisTest.Verify("f", new object[] { false });
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS46_typedassignment_To_stringarray()
        {
            string code =
                @"
            //string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            string error = "1467332  - Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", new object[] { "test" });
            thisTest.Verify("d", new object[] { "1" });
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]

        [Category("Type System")]
        public void TS46_typedassignment_singleton_To_stringarray()
        {
            string code =
                @"
            string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", new object[] { new object[] { "test" } });
            thisTest.Verify("d", new object[] { new object[] { "1" } });
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]

        [Category("Type System")]
        public void TS46_typedassignment_To_chararray()
        {
            string code =
                @"
            string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d", new object[] { '1' });
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]

        [Category("Type System")]
        public void TS46_typedassignment_singleton_To_chararray()
        {
            string code =
                @"
            string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d", new object[] { new object[] { '1' } });
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS047_double_To_Int_insidefunction()
        {
            string code =
                @"
            //thisTest.SetErrorMessage("1467250 Sprint 26 - 3472 - variable modification inside a function does not follow type conversion rules ");
            string error = "1467250 - Sprint 26 - 3472 - variable modification inside a function does not follow type conversion rules ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("t", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS047_double_To_Int_insidefunction_2()
        {
            string code =
                @"
            //thisTest.SetErrorMessage("1467250 Sprint 26 - 3472 - variable modification inside a function does not follow type conversion rules ");
            string error = "1467250 - Sprint 26 - 3472 - variable modification inside a function does not follow type conversion rules ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("t", 10.5);
        }

        [Test]
        [Category("Type System")]
        public void TS048_Param_eachType_To_varArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.5 });
            thisTest.Verify("b", new object[] { 1 });
            thisTest.Verify("c", new object[] { "1.5" });
            thisTest.Verify("d1", new object[] { 1 });
            thisTest.Verify("e", new object[] { false });
            thisTest.Verify("f", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS048_Param_null_To_varArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", 1);
        }


        [Test]
        [Category("Type System")]
        public void TS049_Return_eachType_To_varArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.5 });
            thisTest.Verify("b", new object[] { 1 });
            thisTest.Verify("c", new object[] { "1.5" });
            thisTest.Verify("d1", new object[] { 1 });
            thisTest.Verify("e", new object[] { false });
            thisTest.Verify("f", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS050_Return_eachType_To_intArray()
        {
            //  
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 2 });
            thisTest.Verify("a1", new object[] { 2 });
            thisTest.Verify("b", new object[] { 1 });
            thisTest.Verify("c", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS051_Param_eachType_To_intArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 2 });
            thisTest.Verify("a1", new object[] { 2 });
            thisTest.Verify("b", new object[] { 1 });
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS052_Return_AllTypeTo_doubleArray()
        {
            //  
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.5 });
            thisTest.Verify("a1", new object[] { 1.5 });
            thisTest.Verify("b", new object[] { 1.0 });
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS053_Param_AlltypeTo_doubleArray()
        {
            //  
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.5 });
            thisTest.Verify("a1", new object[] { 1.5 });
            thisTest.Verify("b", new object[] { 1.0 });
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("d1", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS055_Param_AlltypeTo_BoolArray()
        {
            string code =
                @"
            //string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            string error = "1467304 - Sprint 26 - Rev 3781 - null to bool array adds additional rank , it should not ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true, true });
            thisTest.Verify("a1", new object[] { true, true });
            thisTest.Verify("b", new object[] { true, false });
            thisTest.Verify("c", new object[] { true, false });
            thisTest.Verify("c", new object[] { true, false });
            thisTest.Verify("d", new object[] { true, true });
            thisTest.Verify("e", new object[] { false, true });
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS055_null_To_BoolArray_1467304()
        {
            string code =
                @"def func(a : bool[])
            string error = "1467304 - Sprint 26 - Rev 3781 - array of nulls to bool array , not working correctly ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
        }

        [Test]
        [Category("Type System")]
        public void TS055_null_To_BoolArray_1467304_2()
        {
            string code =
                @"def func(a : bool[])
            string error = "1467304 - Sprint 26 - Rev 3781 - array of nulls to bool array , not working correctly";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
        }

        [Test]
        [Category("Type System")]
        public void TS056_Return_AlltypeTo_BoolArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true, true });
            thisTest.Verify("a1", new object[] { true, true });
            thisTest.Verify("b", new object[] { true, false });
            thisTest.Verify("c", new object[] { true, false });
            thisTest.Verify("d", new object[] { true, false });
            thisTest.Verify("e", new object[] { true, true });
            thisTest.Verify("f", new object[] { false, true });
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS056_Return_BoolArray_1467258()
        {
            string code =
                @"
            string error = "1467258 - sprint 26 - Rev 3541 if the return type is bool array , type conversion does not happen for some cases  ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true, true });
            thisTest.Verify("a1", new object[] { true, true });
            thisTest.Verify("b", new object[] { true, false });
            thisTest.Verify("c", new object[] { true, false });
            thisTest.Verify("d", new object[] { true, false });
            thisTest.Verify("e", new object[] { true, true });
        }

        [Test]
        [Category("Type System")]
        public void TS057_Return_Array_1467305()
        {
            string code =
                @"
            string error = "1467305 - Sprint 26 - Rev 3782 adds an adiitonal rank while returning as array, when the rank matches ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true, true });
            thisTest.Verify("a1", new object[] { true, true });
            thisTest.Verify("b", new object[] { true, false });
            thisTest.Verify("c", new object[] { true, false });
            thisTest.Verify("d", new object[] { true, false });
        }

        [Test]
        [Category("Type System")]
        public void TS058_setter_Typeconversion_1467262()
        {
            string code =
                @"
            string error = "1467262 - Sprint 26 - Rev 3543 , setter method does not do type conversion correctly";
            ExecutionMirror mirror = thisTest.RunScriptSource(code, error);
            thisTest.VerifyProperty(mirror, "a", "id", null, 0);
        }

        [Test]
        [Category("Type System")]
        public void TS059Double_To_int_1467203()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS060Double_To_int_1467203()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS061_typeconersion_imperative_1467213()
        {
            string code =
                @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS062_basic_upcoerce_assign()
        {
            string code =
                @"a;
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS063_basic_upcoerce_dispatch()
        {
            string code =
                @"a;
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS063_basic_upcoerce_return()
        {
            string code =
                @"a;
            thisTest.RunScriptSource(code);
            thisTest.Verify("a", new object[] { 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS064_bool_Conditionals_1467278()
        {
            string code =
                @"
            string error = "1467278 - Sprint 26 - Rev 3667 - type conversion fails when evaluating boolean conditionals ";
            ExecutionMirror mirror = thisTest.RunScriptSource(code, error);
            thisTest.Verify("x", true);
            thisTest.Verify("y", false);
        }

        [Test]
        [Category("Type System")]
        public void TS065_doubleToInt_IndexingIntoArray_1467214()
        {
            string code =
                @"
            string error = "1467214 - Sprint 26- Rev 3313 Type Conversion from Double to Int not happening while indexing into array ";
            ExecutionMirror mirror = thisTest.RunScriptSource(code, error);
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("b", 4);
            thisTest.Verify("c", 3);
            thisTest.Verify("d", 4);

        }


        [Test]
        [Category("Type System")]
        public void TS065_doubleToInt_IndexingIntoArray_1467214_2()
        {
            string code =
                @"
            string error = "1467214 - Sprint 26- Rev 3313 Type Conversion from Double to Int not happening while indexing into array ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("b", 2);
        }

        [Test]
        [Category("Type System")]
        public void TS066_Int_To_Char_1467119()
        {
            string code =
                @"
            string error = "1467119 - Sprint24 : rev 2807 : Type conversion issue with char  ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("y", null);
        }

        [Test]
        [Category("Type System")]
        public void TS067_string_To_Char_1467119_2()
        {
            string code =
                @"
            string error = "1467119 - Sprint24 : rev 2807 : Type conversion issue with char  ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("y", null);
        }

        [Test]
        [Category("Type System")]
        public void TS068_Param_singleton_AlltypeTo_BoolArray()
        {
            string code =
                @"
            // string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            string error = "1467306 - Sprint 26 - Rev 3784 - string to bool conversion does not happen in function arguments ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true });
            thisTest.Verify("a1", new object[] { true });
            thisTest.Verify("b", new object[] { true });
            thisTest.Verify("c", new object[] { true });
            thisTest.Verify("c", new object[] { true });
            thisTest.Verify("d", new object[] { true });
            thisTest.Verify("e", new object[] { false });
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS069_Return_singleton_AlltypeTo_BoolArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true });
            thisTest.Verify("a1", new object[] { true });
            thisTest.Verify("b", new object[] { true });
            thisTest.Verify("c", new object[] { true });
            thisTest.Verify("c1", new object[] { true });
            thisTest.Verify("d", new object[] { true });
            thisTest.Verify("e", new object[] { false });
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS070_Param_singleton_AlltypeTo_StringArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", new object[] { "1.5" });
            thisTest.Verify("c1", new object[] { "1" });
            thisTest.Verify("d", null);
            thisTest.Verify("e", null);
            thisTest.Verify("e1", null);
        }

        [Test]
        [Category("Type System")]
        public void TS071_return_singleton_AlltypeTo_StringArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", new object[] { "1.5" });
            thisTest.Verify("c1", new object[] { "1" });
            thisTest.Verify("d", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS072_Param_singleton_AlltypeTo_CharArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", new object[] { '1' });
            thisTest.Verify("d", null);
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS073_return_singleton_AlltypeTo_CharArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", new object[] { '1' });
            thisTest.Verify("d", null);
            thisTest.Verify("e", null);
            thisTest.Verify("e1", null);
        }

        [Test]
        [Category("Type System")]
        public void TS074_Param_singleton_AlltypeTo_UserDefinedArray()
        {
            string code =
                @"
            string error = "1467314 - Sprint 26 - Rev 3805 user defined type to array of user defined type does not upgrade to array ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);

            thisTest.Verify("d1", new object[] { 2 });
            thisTest.Verify("e", null);
            thisTest.Verify("f", null);
        }

        [Test]
        [Category("Type System")]
        public void TS075_return_singleton_AlltypeTo_UserDefinedArray()
        {
            string code =
                @"
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("a1", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("d1", new object[] { 2 });
            thisTest.Verify("e", null);
            thisTest.Verify("e1", null);
        }

        [Test]
        [Category("Type System")]
        public void TS076_UserDefinedCovariance_ArrayPromotion()
        {
            string code =
                @" class A
            string error = "1467251 - sprint 26 - Rev 3485 type conversion from var to var array promotion is not happening ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a1", new object[] { 1 });
            thisTest.Verify("b1", new object[] { 2 });
            thisTest.Verify("b2", new object[] { 0 });
            thisTest.Verify("c", null);
            thisTest.Verify("c1", null);
            thisTest.Verify("c2", null);
        }

        [Test]
        [Category("Type System")]
        public void TS077_userdefinedTobool_1467240_Imperative()
        {
            string code =
                @"class A
            string error = "1467287 Sprint 26 - 3721 user defined to bool conversion does not happen in imperative ";
            thisTest.RunScriptSource(code, error);
            //Assert.Fail("1467240 - Sprint 26 - Rev 3426 user defined type not convertible to bool");
            thisTest.Verify("d", true);
        }

        [Test]
        [Category("Type System")]
        public void TS078_userdefinedToUserdefinedArray()
        {
            string code =
                @"class A
            string error = "";
            thisTest.RunScriptSource(code, error);
            //Assert.Fail("1467240 - Sprint 26 - Rev 3426 user defined type not convertible to bool");
            thisTest.Verify("a1", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS079_typedassignment_nullTo_Anyarray_1467295()
        {
            string code =
                @"
            string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array()
        {
            string code =
                    @"
            string error = "";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_2()
        {
            string code =
                    @"
            string error = "";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { new object[] { 1 } });
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_5()
        {
            string code =
                    @"
            string error = "";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { new object[] { 1 } });
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_3()
        {
            string code =
                    @"
            string error = "";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { new object[] { 1 } });
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_4()
        {
            string code =
                    @"
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_6()
        {
            string code =
                    @"
                    ;
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { 1 });
            thisTest.Verify("t", new object[] { 1 });
            thisTest.Verify("u", new object[] { 1 });
            thisTest.Verify("v", null);
            thisTest.Verify("w", null);
            thisTest.Verify("x", null);
            thisTest.Verify("y", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_7()
        {
            string code =
                    @"
                    ;
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { 1 });
            thisTest.Verify("t", new object[] { 1.0 });
            thisTest.Verify("u", new object[] { 1 });
            thisTest.Verify("v", new object[] { true });
            thisTest.Verify("w", new object[] { "1" });
            thisTest.Verify("x", new object[] { '1' });
            thisTest.Verify("y", new object[] { 0 });
            thisTest.Verify("z", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_8()
        {
            string code =
                    @"
                    ;
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { 1.0 });
            thisTest.Verify("t", new object[] { 1.0 });
            thisTest.Verify("u", new object[] { 1.0 });
            thisTest.Verify("v", null);
            thisTest.Verify("w", null);
            thisTest.Verify("x", null);
            thisTest.Verify("y", null);
            thisTest.Verify("z", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_9()
        {
            string code =
                    @"
                    ;
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { true });
            thisTest.Verify("t", new object[] { true });
            thisTest.Verify("u", new object[] { true });
            thisTest.Verify("v", new object[] { true });
            thisTest.Verify("w", new object[] { true });
            thisTest.Verify("x", new object[] { true });
            thisTest.Verify("y", new object[] { true });
            thisTest.Verify("z", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_10()
        {
            string code =
                    @"
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_11()
        {
            string code =
                    @"
                    ;
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", null);
            thisTest.Verify("t", null);
            thisTest.Verify("u", null);
            thisTest.Verify("v", null);
            thisTest.Verify("w", new object[] { "1" });
            thisTest.Verify("x", new object[] { "1" });
            thisTest.Verify("y", null);
            thisTest.Verify("z", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_Defect_1467235_coercion_from_singleton_array_12()
        {
            string code =
                    @"
                    ;
            string error = "1467235 - Sprint25: rev 3411 : When class property is a collection and a single value is passed to it, it should be coerced to a collection";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("r", null);
            thisTest.Verify("t", null);
            thisTest.Verify("u", null);
            thisTest.Verify("v", null);
            thisTest.Verify("w", null);
            thisTest.Verify("x", new object[] { '1' });
            thisTest.Verify("y", null);
            thisTest.Verify("z", null);
        }

        [Test]
        [Category("Type System")]
        public void TZ01_1467320_single_To_Dynamicarray()
        {
            string code =
                    @"
            string error = "1467320 Sprint 27 - Rev 3873 ,Upgrade to array does not happen if the member property define as dynamic array and single value is assigned ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d", new object[] { 0 });
        }


        [Test]
        [Category("Type System")]
        public void TZ01_1467320_single_To_Dynamicarray_2()
        {
            string code =
                    @"
            string error = "1467320 Sprint 27 - Rev 3873 ,Upgrade to array does not happen if the member property define as dynamic array and single value is assigned ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d", new object[] { 0, 1 });
        }


        [Test]
        [Category("Type System")]
        public void TZ01_1467320_single_To_Dynamicarray_3()
        {
            string code =
                    @"
            string error = "1467320 Sprint 27 - Rev 3873 ,Upgrade to array does not happen if the member property define as dynamic array and single value is assigned ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d", new object[] { 0, new object[] { 1 } });
        }

        [Test]
        [Category("Type System")]
        public void TS080_string_To_Bool_1467306()
        {
            string code =
                    @"
            string error = "1467306 - Sprint 26 - Rev 3784 - string to bool conversion does not happen in function arguments ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("c", true);
            thisTest.Verify("d", false);
        }

        [Test]
        [Category("Type System")]
        public void TS081_Userdefined_To_single_1467308()
        {
            string code =
                    @"
            string error = "1467308 - Sprint 26 - Rev 3786 - userdefined type array to singleton conversion must return null since conversion not possible ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("e", null);
        }

        [Test]
        [Category("Type System")]
        public void TS081_Userdefined_To_single_1467308_2()
        {
            string code =
                    @"
            string error = "1467308 - Sprint 26 - Rev 3786 - userdefined type array to singleton conversion must return null since conversion not possible ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("e", new object[] { 5 });
        }

        [Test]
        [Category("Type System")]
        public void TS081_Userdefined_To_single_1467308_3()
        {
            string code =
                    @"
            string error = "1467308 - Sprint 26 - Rev 3786 - userdefined type array to singleton conversion must return null since conversion not possible ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("e", 5);
        }

        [Test]
        [Category("Type System")]
        public void TS081_Userdefined_To_single_1467308_4()
        {
            string code =
                    @"
            string error = "1467308 - Sprint 26 - Rev 3786 - userdefined type array to singleton conversion must return null since conversion not possible ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("e", null);
        }


        [Test]
        [Category("Type System")]
        public void TS082_return_userdefined_To_BoolArray_1467310()
        {
            string code =
                    @"
            string error = "147310 - Sprint 26 - Rev 3786 user defined to bool array - array conversion does not happen ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d", new object[] { true });
        }

        [Test]
        [Category("Type System")]
        public void TS082_Param_userdefined_To_BoolArray_1467310()
        {
            string code =
                    @"
            string error = "1467310 -Sprint 26 - Rev 3786 user defined to bool array - array conversion does not happen ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d", new object[] { true });
        }

        [Test]
        [Category("Type System")]
        public void TS082_assign_userdefined_To_BoolArray_1467310()
        {
            string code =
                    @"
            string error = "147310 - Sprint 26 - Rev 3786 user defined to bool array - array conversion does not happen ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("b", new object[] { true, true });
        }

        [Test]
        [Category("Type System")]
        public void TS082_assign2_userdefined_To_BoolArray_1467310()
        {
            string code =
                    @"
            string error = "147310 - Sprint 26 - Rev 3786 user defined to bool array - array conversion does not happen ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("b", new object[] { true });
        }

        [Test]
        [Category("Type System")]
        public void TS082_dispatch2_userdefined_To_BoolArray_1467310()
        {
            string code =
                    @"
            string error = "147310 - Sprint 26 - Rev 3786 user defined to bool array - array conversion does not happen ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("o", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS082_dispatch3_userdefined_To_BoolArray_1467310()
        {
            string code =
                    @"
            string error = "147310 - Sprint 26 - Rev 3786 user defined to bool array - array conversion does not happen ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("o", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS083_Param_char_To_String_1467311()
        {
            string code =
                    @"
            string error = "1467311 - Sprint 26 - Rev 3788 - Char to String conversion not happening ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("c1", "1");
        }

        [Test]
        [Category("Type System")]
        public void TS083_Param_char_To_StringArray_1467311()
        {
            string code =
                    @"
            string error = "1467311 - Sprint 26 - Rev 3788 - Char to String conversion not happening ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("c1", new object[] { "1" });
        }

        [Test]
        [Category("Type System")]
        public void TS084_Param_UserDefine_To_UserDefinedArray_1467314()
        {
            string code =
                    @"
            string error = "1467314 Sprint 26 - Rev 3805 user defined type to array of user defined type does not upgrade to array ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d1", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS085_return_UserDefine_To_UserDefinedArray_1467314()
        {
            string code =
                    @"
            string error = "1467314 Sprint 26 - Rev 3805 user defined type to array of user defined type does not upgrade to array ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d1", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS086_param_null_Array_replication_1467316()
        {
            string code =
                    @"
            string error = "1467316 - Sprint 26 - Rev 3831 function arguments - if the first argument in an array is null it replicates, when not expected";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("a1", new object[] { null, 2, 6 });
        }

        [Test]
        [Category("Type System")]
        public void TS087_arrayUpgrade_function_arguments_1457470()
        {
            string code =
                    @"
            string error = "1467316 - Sprint 26 - Rev 3831 function arguments - if the first argument in an array is null it replicates, when not expected";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("b1", new object[] { 1 });
        }

        [Test]
        [Category("Type System")]
        public void TS088_arrayUpgrade_function_return()
        {
            string code =
                    @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("c", new object[] { 0, null });
        }

        [Test]
        [Category("Type System")]
        public void TS089_arrayUpgrade_function_return_intArray_rankmismtach()
        {
            string code =
                    @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("c", new object[] { 0, null });
        }

        [Test]
        [Category("Type System")]
        public void TS090_arrayUpgrade_function_return_doubleArray_rankmismtach()
        {
            string code =
                    @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("c", new object[] { 0.0, null });
        }

        [Test]
        [Category("Type System")]
        public void TS091_arrayUpgrade_function_return_boolArray_rankmismtach()
        {
            string code =
                    @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("c", new object[] { false, null });
        }

        [Test]
        [Category("Type System")]
        public void TS092_arrayUpgrade_function_return_stringArray_rankmismtach()
        {
            string code =
                    @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("c", new object[] { null, null });
        }

        [Test]
        [Category("Type System")]
        public void TS093_Param_notypedefined_indexing_Userdefined()
        {
            string code =
                    @"
            string error = "1467309 - rev 3786 :  Warning:Couldn't decide which function to execute... coming from valid code ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("z", 0);
        }

        [Test]
        [Category("Type System")]
        public void TS094_Param_notypedefined_single_Userdefined()
        {
            string code =
                    @"
            thisTest.RunScriptSource(code);
            thisTest.Verify("z", 0);
        }

        [Test]
        [Category("Type System")]
        public void TS094_Class_member_single_ToDynamicArray_Userdefined_1467320()
        {
            string code =
                    @"
            //string error = "1467320 - Sprint 27 - Rev 3873 ,Upgrade to array does not happen if the member property define as dynamic array and single value is assigned ";
            string error = "";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("d", 0);
        }

        [Test]

        [Category("Type System")]
        public void TS0120_typedassignment_To_Jagged_Vararray()
        {
            string code =
                @"
            string error = "DNL-1467515 Regression : Dot operation on jagged arrays is giving unexpected null ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1, new object[] { 2, 3 }, new object[] { new object[] { 4 }, 3 } });
            thisTest.Verify("b", new object[] { 1.1, new object[] { 2.2, 3.3 } });
            thisTest.Verify("c", new object[] { "a", new object[] { "a" } });
            thisTest.Verify("d", new object[] { 'c', new object[] { 'c' } });
            thisTest.Verify("e1", new object[] { 1, new object[] { 1 } });
            thisTest.Verify("f", new object[] { true, new object[] { true } });
            thisTest.Verify("g", new object[] { null, new object[] { null } });
        }


        [Test]
        [Category("Type System")]
        public void TS0121_typedassignment_To_Jagged_Intarray()
        {
            string code =
                @"
            string error = "DNL-1467515 Regression : Dot operation on jagged arrays is giving unexpected null ";
            thisTest.VerifyRunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1, new object[] { 2, new object[] { 3 } } });
            thisTest.Verify("b", new object[] { 1, new object[] { 1 } });
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS0122_typedassignment_To_Jagged_doublearray()
        {
            string code =
                @"
            //string error = "1467294 - Sprint 26 - Rev 3763 - in typed assignment, array promotion does not occur in some cases";
            string error = "1467332 Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";

            thisTest.VerifyRunScriptSource(code, error);
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { 1.0, null });
            thisTest.Verify("b", new object[] { 1.1, null });
            thisTest.Verify("c", null);
            thisTest.Verify("d", null);
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS0123_typedassignment_To_Jagged_boolarray()
        {
            string code =
                @"
            //string error = "1467295- Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            string error = "1467332 Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", new object[] { true, new object[] { true } });
            thisTest.Verify("b", new object[] { true, new object[] { true } });
            thisTest.Verify("c", new object[] { true, new object[] { true } });
            thisTest.Verify("d", new object[] { true, new object[] { true } });
            thisTest.Verify("e", new object[] { true, new object[] { true } });
            thisTest.Verify("f", new object[] { true, new object[] { true } });
            thisTest.Verify("g", null);
        }


        [Test]
        [Category("Type System")]
        public void TS0124_typedassignment_To_Jagged_stringarray()
        {
            string code =
                @"
            //string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            string error = "1467332 Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", new object[] { "test", new object[] { "test" } });
            thisTest.Verify("d", new object[] { "1", new object[] { "1" } });
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void TS0125_typedassignment_To_Jagged_chararray()
        {
            string code =
                @"
            //string error = "1467295 - Sprint 26 : rev 3766 null gets converted into an array of nulls (while converting into array of any type) when the conversion is not allowed ";
            string error = "1467332 Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            thisTest.RunScriptSource(code, error);
            thisTest.Verify("a", null);
            thisTest.Verify("b", null);
            thisTest.Verify("c", null);
            thisTest.Verify("d", new object[] { "1", new object[] { "1" } });
            thisTest.Verify("e1", null);
            thisTest.Verify("f", null);
            thisTest.Verify("g", null);
        }

        [Test]
        [Category("Type System")]
        public void arrayRankmismtach_function_Param_1467326()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "z", new object[] { new object[] { 3 } });
        }

        [Test]
        [Category("Type System")]
        public void arrayRankmismtach_function_Return_1467326()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "z", new object[] { new object[] { 3 } });
        }

        [Test]
        [Category("Type System")]
        public void TS126_Param_eachType_Array_To_VarArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { 3 } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { "1.5" } });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { '1' } });
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { 3 } });
            TestFrameWork.Verify(mirror, "h1", new object[] { new object[] { 0 } });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS126_Return_eachType_Array_To_VarArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { new object[] { 3 } } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { new object[] { 3.0 } } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { new object[] { "1.5" } } });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { new object[] { '1' } } });
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { new object[] { 3 } } });
            TestFrameWork.Verify(mirror, "h1", new object[] { new object[] { new object[] { 0 } } });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS127_Param_eachType_Array_To_IntArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { 3 } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { 3 } });
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", null);
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { 3 } });
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS128_Return_eachType_Array_To_IntArray()
        {
            string code =
                @"
            string error = "DNL-1467480 Regression : Dot Operation on instances using replication returns single null where multiple nulls are expected";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { new object[] { 3 } } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { new object[] { 3 } } });
            TestFrameWork.Verify(mirror, "c", new object[] { null });
            TestFrameWork.Verify(mirror, "d", new object[] { null });
            TestFrameWork.Verify(mirror, "e", new object[] { null });
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { new object[] { 3 } } });
            TestFrameWork.Verify(mirror, "h1", new object[] { null });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS129_Param_eachType_Array_To_DoubleArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", null);
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS130_Return_eachType_Array_To_DoubleArray()
        {
            string code =
                @"
            string error = "DNL-1467480 Regression : Dot Operation on instances using replication returns single null where multiple nulls are expected";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { new object[] { 3.0 } } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { new object[] { 3.0 } } });
            TestFrameWork.Verify(mirror, "c", new object[] { null });
            TestFrameWork.Verify(mirror, "d", new object[] { null });
            TestFrameWork.Verify(mirror, "e", new object[] { null });
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { new object[] { 3.0 } } });
            TestFrameWork.Verify(mirror, "h1", new object[] { null });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS131_Param_eachType_Array_To_BoolArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "h", new object[] { new object[] { true } });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS132_Return_eachType_Array_To_BoolArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "f1", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "h", new object[] { new object[] { new object[] { true } } });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS133_Param_eachType_Array_To_StringArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", null);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { "1.5" } });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { "1" } });
            TestFrameWork.Verify(mirror, "f1", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS134_Return_eachType_Array_To_StringArray()
        {
            string code =
                @"
            string error = "DNL-1467480 Regression : Dot Operation on instances using replication returns single null where multiple nulls are expected";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { null });
            TestFrameWork.Verify(mirror, "b", new object[] { null });
            TestFrameWork.Verify(mirror, "c", new object[] { null });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { new object[] { "1.5" } } });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { new object[] { "1" } } });
            TestFrameWork.Verify(mirror, "f1", new object[] { null });
            TestFrameWork.Verify(mirror, "h1", new object[] { null });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS135_Param_eachType_Array_To_charArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", null);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { '1' } });
            TestFrameWork.Verify(mirror, "f1", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS136_Return_eachType_Array_To_CharArray()
        {
            string code =
                @"
            string error = "DNL-1467480 Regression : Dot Operation on instances using replication returns single null where multiple nulls are expected";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { null });
            TestFrameWork.Verify(mirror, "b", new object[] { null });
            TestFrameWork.Verify(mirror, "c", new object[] { null });
            TestFrameWork.Verify(mirror, "d", new object[] { null });
            TestFrameWork.Verify(mirror, "e", new object[] { new object[] { new object[] { '1' } } });
            TestFrameWork.Verify(mirror, "f1", new object[] { null });
            TestFrameWork.Verify(mirror, "h1", new object[] { null });
            TestFrameWork.Verify(mirror, "i", new object[] { null });
        }

        [Test]
        [Category("Type System")]
        public void TS0137_Param_eachType_Array_To_Jagged_VarArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, new object[] { 3 } });
            TestFrameWork.Verify(mirror, "b", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "c", new object[] { true, new object[] { false } });
            TestFrameWork.Verify(mirror, "d", new object[] { "1.5", new object[] { "1.5" } });
            TestFrameWork.Verify(mirror, "e", new object[] { '1', new object[] { '1' } });
            TestFrameWork.Verify(mirror, "f1", new object[] { 3 });
            TestFrameWork.Verify(mirror, "h1", new object[] { 0, new object[] { 0 } });
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS0138_Return_eachType_Array_To_Jagged_VarArray()
        {
            string code =
                 @"
            //string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467334 - Sprint 27 - Rev 3966 - when return type is arbitrary rank , type conversion reduces array rank , where it is not expected to ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, new object[] { 3 } });
            TestFrameWork.Verify(mirror, "b", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "c", new object[] { true, new object[] { false } });
            TestFrameWork.Verify(mirror, "d", new object[] { "1.5", new object[] { "1.5" } });
            TestFrameWork.Verify(mirror, "e", new object[] { '1', new object[] { '1' } });
            TestFrameWork.Verify(mirror, "f1", new object[] { 3 });
            TestFrameWork.Verify(mirror, "h1", new object[] { 0, new object[] { 0 } });
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS139_Param_eachType_Array_To_jagged_IntArray()
        {
            string code =
                  @"
            //string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467334 - Sprint 27 - Rev 3966 - when return type is arbitrary rank , type conversion reduces array rank , where it is not expected to ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, new object[] { 3 } });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, new object[] { 3 } });
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", null);
            TestFrameWork.Verify(mirror, "f1", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", null);
        }

        [Test]
        [Category("Type System")]
        public void TS140_Return_eachType_Array_To_Jagged_IntArray()
        {
            string code =
                @"
            //string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467334 - Sprint 27 - Rev 3966 - when return type is arbitrary rank , type conversion reduces array rank , where it is not expected to ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, new object[] { 3 } });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, new object[] { 3 } });
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", null);
            TestFrameWork.Verify(mirror, "f1", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS141_Param_eachType_Array_To_jagged_DoubleArray()
        {
            string code =
                @"
            // string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467334 - Sprint 27 - Rev 3966 - when return type is arbitrary rank , type conversion reduces array rank , where it is not expected to ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "b", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", null);
            TestFrameWork.Verify(mirror, "f1", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS142_Return_eachType_Array_To_Jagged_DoubleArray()
        {
            string code =
                              @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "b", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", null);
            TestFrameWork.Verify(mirror, "f1", new object[] { 3.0, new object[] { 3.0 } });
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS143_Param_eachType_Array_To_Jagged_BoolArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "b", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "c", new object[] { true, new object[] { false } });
            TestFrameWork.Verify(mirror, "d", new object[] { true, new object[] { false } });
            // TestFrameWork.Verify(mirror, "e", new object[] { true,new object[] { false } });
            TestFrameWork.Verify(mirror, "f", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "h1", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS144_Return_eachType_Array_To_Jagged_BoolArray()
        {
            string code =
                 @"
            //string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467334 - Sprint 27 - Rev 3966 - when return type is arbitrary rank , type conversion reduces array rank , where it is not expected to ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "b", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "c", new object[] { true, new object[] { false } });
            TestFrameWork.Verify(mirror, "d", new object[] { true, new object[] { false } });
            TestFrameWork.Verify(mirror, "e", new object[] { true, new object[] { false } });
            TestFrameWork.Verify(mirror, "f", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "h1", new object[] { true, new object[] { true } });
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS147_Param_eachType_Array_To_jagged_StringArray()
        {
            string code =
                 @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a1", null);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { "1.5" }, new object[] { "1.5" } });
            TestFrameWork.Verify(mirror, "e", new object[] { "1", new object[] { "1" } });
            TestFrameWork.Verify(mirror, "f", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS148_Return_eachType_Array_To_jagged_StringArray()
        {
            string code =
                @"
            //string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467332 - Sprint 27 - Rev 3956 {null} to array upgrdation must null out ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a1", null);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { "1.5" }, new object[] { "1.5" } });
            TestFrameWork.Verify(mirror, "e", new object[] { "1", new object[] { "1" } });
            TestFrameWork.Verify(mirror, "f", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS149_Param_eachType_Array_To_Jagged_charArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a1", null);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", new object[] { '1', new object[] { '1' } });
            TestFrameWork.Verify(mirror, "f1", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS150_Return_eachType_Array_To_jagged_CharArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a1", null);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", null);
            TestFrameWork.Verify(mirror, "d", null);
            TestFrameWork.Verify(mirror, "e", new object[] { '1', new object[] { '1' } });
            TestFrameWork.Verify(mirror, "f1", null);
            TestFrameWork.Verify(mirror, "h1", null);
            TestFrameWork.Verify(mirror, "i", new object[] { null, new object[] { null } });
        }

        [Test]
        [Category("Type System")]
        public void TS0151_Param_eachType_Heterogenous_Array_To_VarArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3.0, true, "1", '1', 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3.0, true, "1", '1', 3, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3.0, true, "1", '1', 3, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3.0, true, "1", '1', 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3.0, true, "1", '1', 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0152_NullingOutTest()
        {
            string code =
                @"
            string error = "DNL-1467307 Sprint 25 - Rev 3784 : Method resolution failure on member function when actual parameter is the subtype of the formal parameter type";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "e", null);
        }

        [Test]
        [Category("Type System")]
        public void TS0152_NullingOutTest_a()
        {
            string code =
                @"
            string error = "DNL-1467307 Sprint 25 - Rev 3784 : Method resolution failure on member function when actual parameter is the subtype of the formal parameter type";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "e", null);
        }

        [Test]
        [Category("Type System")]
        public void TS0152_NullingOutTest_b()
        {
            string code =
                @"
            string error = "DNL-1467307 Sprint 25 - Rev 3784 : Method resolution failure on member function when actual parameter is the subtype of the formal parameter type";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "e", new object[] { 5 });
        }

        [Test]
        [Category("Type System")]
        public void TS0152_NullingOutTest_c()
        {
            string code =
                @"
            string error = "DNL-1467307 Sprint 25 - Rev 3784 : Method resolution failure on member function when actual parameter is the subtype of the formal parameter type";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "e", null);
        }

        [Test]
        [Category("Type System")]
        public void TS0152_Defect_Analysis()
        {
            string code =
                @"
            string error = "DNL-1467307 Sprint 25 - Rev 3784 : Method resolution failure on member function when actual parameter is the subtype of the formal parameter type";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "e", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS0152_Defect_Analysis_a()
        {
            string code =
                @"
            string error = "DNL-1467307 Sprint 25 - Rev 3784 : Method resolution failure on member function when actual parameter is the subtype of the formal parameter type";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "e", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS0160_Param_eachType_Heterogenous_Array_To_VarArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3.0, true, "1", '1', 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3.0, true, "1", '1', 3, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3.0, true, "1", '1', 3, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3.0, true, "1", '1', 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3.0, true, "1", '1', 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS161_Param_eachType_Heterogenous_Array_To_VarArray()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3.0, true, "1", '1', 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3.0, true, "1", '1', 3, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3.0, true, "1", '1', 3, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3.0, true, "1", '1', 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3.0, true, "1", '1', 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0162_Param_ArrayReduction_varArray_Var()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3.0, true, "1", '1', 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3.0, true, "1", '1', 3, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3.0, true, "1", '1', 3, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3.0, true, "1", '1', 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3.0, true, "1", '1', 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0163_Param_ArrayReduction_heterogenous_To_Int()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3, null, null, null, 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3, null, null, null, 3, null });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3, null, null, null, 3, null, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3, null, null, null, 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3, null, null, null, 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0164_Param_ArrayReduction_heterogenous_To_double()
        {
            string code =
                @"
            string error = "1467345 - Sprint 27 - Rev 4011 function does not replicate when hetrogenous array with type mismatch are passed as argument ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3.0, 3.0, null, null, null, 3.0 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3.0, 3.0, null, null, null, 3.0, null });
            TestFrameWork.Verify(mirror, "c", new object[] { 3.0, 3.0, null, null, null, 3.0, null, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3.0, 3.0, null, null, null, 3.0, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3.0, 3.0, null, null, null, 3.0 });
            TestFrameWork.Verify(mirror, "f", new object[] { null, null, 3.0, 3.0, null, 3.0, null });
        }

        [Test]
        [Category("Type System")]
        public void TS0165_Param_ArrayReduction_heterogenous_To_bool()
        {
            string code =
                @"
            string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { true, true, true, true, true, true });
            TestFrameWork.Verify(mirror, "b", new object[] { true, true, true, true, true, true, true });
            TestFrameWork.Verify(mirror, "c", new object[] { true, true, true, true, true, true, true, null });
            TestFrameWork.Verify(mirror, "d", new object[] { true, true, true, true, true, true, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, true, true, true, true, true, true });
        }

        [Test]
        [Category("Type System")]
        public void TS0166_Param_ArrayReduction_heterogenous_To_UserDefined()
        {
            string code =
                @"
            //string error = "1467326 Sprint 27 - Rev 3905 when there is rank mismatch for function , array upagrades to 1 dimension higer than expected ";
            string error = "1467376 - Sprint 27 - rev 4184 - when heterogenous array is passed and the type is user defined , it does not replicate unless the first item is user defined ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { null, null, null, null, null, null });
            TestFrameWork.Verify(mirror, "b", new object[] { null, null, null, null, null, null, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { null, null, null, null, null, null, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { null, null, null, null, null, null, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, null, null, null, null, null, null });
        }

        [Test]
        [Category("Type System")]
        public void TS0170_typeconversion_replication_oneargument()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 3, 4 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0171_typeconversion_replication_botharguments()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0171_typeconversion_replication_botharguments_2()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 2, 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { 2, 3 }, new object[] { 3, 4 } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { 2, 3 }, new object[] { 3, 5 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0171_typeconversion_replication_botharguments_3()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 2, 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { 2, 3 }, new object[] { 3, 4 } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { 2, 3 }, new object[] { 3, 5 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0171_typeconversion_replication_botharguments_4()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 2, 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
            TestFrameWork.Verify(mirror, "c", new object[] { new object[] { 2, 3 }, new object[] { 3, 4 } });
            TestFrameWork.Verify(mirror, "d", new object[] { new object[] { 2, 3 }, new object[] { 3, 5 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0172_typeconversion_replication_Var_one_argument()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 3, 4 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0173_typeconversion_replication_Var_botharguments()
        {
            string code =
                @"
            string error = "1467355 - Sprint 27 Rev 4014 , it replicates with maximum combination where as its expected to zipped ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0174_typeconversion_replication()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0175_typeconversion_replication()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0176_typeconversion_replication_userdefined()
        {
            string code =
                @"
            string error = "1467355 - Sprint 27 Rev 4014 , it replicates with maximum combination where as its expected to zipped ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { true, new object[] { 1, 1 } }, new object[] { false, new object[] { 1, 1 } } });
        }

        [Test]
        [Category("Type System")]
        public void TS0177_typeconversion_replication()
        {
            string code =
                @"
            string error = "1467356 -Sprint 27 - Rev4014 - function argument with jagged array - its expected to replicate for the attached code ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { 1, 2, 3, new object[] { 4 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0178_typeconversion_replication()
        {
            string code =
                @"
            string error = "1467355 Sprint 27 Rev 4014 , it replicates with maximum combination where as its expected to zipped ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 4, 6 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0179_typeconversion_replication()
        {
            string code =
                @"

            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 2, 3 }, new object[] { 3, 4 } });
        }


        [Test]
        [Category("Type System")]
        public void TS0180_typeconversion_replication()
        {
            string code =
                @"

            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "a", new object[] { 0, 1 });
            TestFrameWork.Verify(mirror, "b", new object[] { 0, -1 });
            TestFrameWork.Verify(mirror, "c", new object[] { 2, 4 });
        }

        [Test]
        [Category("Type System")]
        public void TS0181_typeconversion_replication_class()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "a", new object[] { 0, 1 });
            TestFrameWork.Verify(mirror, "b", new object[] { 0, -1 });
            TestFrameWork.Verify(mirror, "c", new object[] { 2, 4 });
        }

        [Test]
        [Category("Type System")]
        public void TS0182_typeconversion_replication_arithematic()
        {
            string code =
                @"
            string error = "1467359 - Sprint 27 - rev 4017 arithematic operations , the type must be converted higer up in the chain , currently does based on the first item in the array";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 5.3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0183_TypeConversion()
        {
            string code =
                @"
            string error = "1467359 - Sprint 27 - rev 4017 arithematic operations , the type must be converted higer up in the chain , currently does based on the first item in the array";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 5.3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0184_TypeConversion()
        {
            string code =
                @"
            string error = "1467359 - Sprint 27 - rev 4017 arithematic operations , the type must be converted higer up in the chain , currently does based on the first item in the array";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "test", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS0184_TypeConversion_1467352()
        {
            string code =
                @"
            string error = "1467359 - Sprint 27 - rev 4017 arithematic operations , the type must be converted higer up in the chain , currently does based on the first item in the array";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "test", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS0184_TypeConversion_1467352_2()
        {
            string code =
                @"
            string error = "1467352 - [Language] Mixed array return type is incorrect";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "test", 1);
        }

        [Test]
        [Category("Type System")]
        public void TS0185_TypeConversion_1467291()
        {
            string code =
                @"
            string error = "1467291 - Assigning a value to a typed array doesn't respect the type ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { null, 2, 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0186_TypeConversion_replicate()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b1", new object[] { new object[] { 1 }, new object[] { 2 }, new object[] { 3 } });
        }

        [Test]
        [Category("Type System")]
        public void TS0187_TypeConversion_builtin_Sum()
        {
            string code =
                @"
            string error = "1467362 Sprint 27 - Rev 4048 function Sum fails if non convertible types are give nas input ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "sum2", 4);
        }

        [Test]
        [Category("Type System")]
        public void TS0189_TypeConversion_conditionals()
        {
            string code =
                @"
            string error = "1467361 -Sprint 27 - Rev 4037 - [Design Issue]conditionals with empty arrays and ararys with different ranks ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "x", null);
            TestFrameWork.Verify(mirror, "z", false);
            TestFrameWork.Verify(mirror, "z2", false);
            TestFrameWork.Verify(mirror, "z3", false);
            TestFrameWork.Verify(mirror, "z4", false);
        }

        [Test]
        [Category("Type System")]
        public void TS0189_TypeConversion_conditionals_1465293_1()
        {
            string code =
                @"
            string error = " ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", false);
            TestFrameWork.Verify(mirror, "b", true);
            TestFrameWork.Verify(mirror, "c", true);
            TestFrameWork.Verify(mirror, "d", false);
        }

        [Test]
        [Category("Type System")]
        public void TS0189_TypeConversion_conditionals_1465293_2()
        {
            string code =
                @"
            string error = " ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", false);
            TestFrameWork.Verify(mirror, "b", null);
            TestFrameWork.Verify(mirror, "c", false);
            TestFrameWork.Verify(mirror, "d", true);
            TestFrameWork.Verify(mirror, "e", true);
            TestFrameWork.Verify(mirror, "f", false);
        }

        [Test]
        [Category("Type System")]
        public void TS190_Param_eachType_Heterogenous_Array_To_VarArray()
        {
            string code =
                @"
            string error = "";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3.0, true, "1", '1', 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3.0, true, "1", '1', 3, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3.0, true, "1", '1', 3, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3.0, true, "1", '1', 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3.0, true, "1", '1', 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0191_Param_ArrayReduction_heterogenous_To_IntArray()
        {
            string code =
                @"
            string error = "1467224 - Sprint25: rev 3352: Type conversion - method dispatch over heterogeneous array is not correct ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3, 3, null, null, null, 3 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3, 3, null, null, null, 3, null });
            TestFrameWork.Verify(mirror, "c", new object[] { 3, 3, null, null, null, 3, null, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3, 3, null, null, null, 3, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3, 3, null, null, null, 3 });
        }

        [Test]
        [Category("Type System")]
        public void TS0192_Param_ArrayReduction_heterogenous_To_doubleArray()
        {
            string code =
                @"
            string error = "1467224 - Sprint25: rev 3352: Type conversion - method dispatch over heterogeneous array is not correct ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { 3.0, 3.0, null, null, null, 3.0 });
            TestFrameWork.Verify(mirror, "b", new object[] { 3.0, 3.0, null, null, null, 3.0, null });
            TestFrameWork.Verify(mirror, "c", new object[] { 3.0, 3.0, null, null, null, 3.0, null, null });
            TestFrameWork.Verify(mirror, "d", new object[] { 3.0, 3.0, null, null, null, 3.0, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, 3.0, 3.0, null, null, null, 3.0 });
            TestFrameWork.Verify(mirror, "f", new object[] { null, null, 3.0, 3.0, null, 3.0, null });
        }

        [Test]
        [Category("Type System")]
        public void TS0193_Param_ArrayReduction_heterogenous_To_boolArray()
        {
            string code =
                @"
            string error = "1467224 - Sprint25: rev 3352: Type conversion - method dispatch over heterogeneous array is not correct ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { true, true, true, true, true, true });
            TestFrameWork.Verify(mirror, "b", new object[] { true, true, true, true, true, true, true });
            TestFrameWork.Verify(mirror, "c", new object[] { true, true, true, true, true, true, true, null });
            TestFrameWork.Verify(mirror, "d", new object[] { true, true, true, true, true, true, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, true, true, true, true, true, true });
        }

        [Test]
        [Category("Type System")]
        public void TS0194_Param_ArrayReduction_heterogenous_To_UserDefinedArray()
        {
            string code =
                @"
            string error = "1467376 - Sprint 27 - rev 4184 - when heterogenous array is passed and the type is user defined , it does not replicate unless the first item is user defined ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "a", new object[] { null, null, null, null, null, null });
            TestFrameWork.Verify(mirror, "b", new object[] { null, null, null, null, null, null, 0 });
            TestFrameWork.Verify(mirror, "c", new object[] { null, null, null, null, null, null, 0, null });
            TestFrameWork.Verify(mirror, "d", new object[] { null, null, null, null, null, null, null });
            TestFrameWork.Verify(mirror, "e", new object[] { null, null, null, null, null, null, null });
        }

        [Test]
        [Category("Type System")]
        public void TS0195_heterogenousarray_To_UserDefinedArray()
        {
            string code =
                @"
            string error = "1467376 - Sprint 27 - rev 4184 - when heterogenous array is passed and the type is user defined , it does not replicate unless the first item is user defined ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b", new object[] { null, 0, 0 });

        }

        [Test]
        [Category("Type System")]
        public void TS0196_heterogenousarray_To_UserDefinedArray()
        {
            string code =
                @"
            string error = "1467376 - Sprint 27 - rev 4184 - when heterogenous array is passed and the type is user defined , it does not replicate unless the first item is user defined ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b", new object[] { null, 0, 0 });
        }

        [Test]
        [Category("Type System")]
        public void TS0197_getter_dotoperator_1467419()
        {
            string code =
                @"
            string error = "1467419 - Sprint 29 - Rev 4502 - the .operator is doing rank reduction where it is expected to replicate ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "z", new object[] { new object[] { 1 }, new object[] { new object[] { 0 }, new object[] { 1 } } });
        }

        [Test]
        [Category("Type System")]
        public void TS0198_method_resolution_1467273()
        {
            string code =
                @"
            string error = "1467419 - Sprint 29 - Rev 4502 - the .operator is doing rank reduction where it is expected to replicate ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "u", 1);
            TestFrameWork.Verify(mirror, "v", 2);
            TestFrameWork.Verify(mirror, "w", 2);
            TestFrameWork.Verify(mirror, "x", 2);
            TestFrameWork.Verify(mirror, "y", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS0198_method_resolution_1467273_2()
        {
            string code =
                @"
            string error = "1467419 - Sprint 29 - Rev 4502 - the .operator is doing rank reduction where it is expected to replicate ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "u", 1);
            TestFrameWork.Verify(mirror, "v", 3);
            TestFrameWork.Verify(mirror, "w", 3);
            TestFrameWork.Verify(mirror, "x", 3);
            TestFrameWork.Verify(mirror, "y", 3);
        }

        [Test]
        [Category("Type System")]
        public void TS0198_method_resolution_1467273_3()
        {
            string code =
                @"
            string error = "1467419 - Sprint 29 - Rev 4502 - the .operator is doing rank reduction where it is expected to replicate ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "u", 1);
            TestFrameWork.Verify(mirror, "v", 3);
            TestFrameWork.Verify(mirror, "w", 3);
            TestFrameWork.Verify(mirror, "x", new object[] { 1, 1 });
            TestFrameWork.Verify(mirror, "y", 3);
        }

        [Test]
        public void replication_1467451()
        {
            string code =
                @"
            string error = "DNL-1467451 Sprint 29 - Rev 4596 , error thrown where not expected ";
            var mirror = thisTest.RunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "d", new object[] { 46.0, 47.0, 47.0 });
            thisTest.VerifyBuildWarningCount(0);
        }

        [Test]
        public void indexintoarray_left_1467462_1()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "x", new object[] { 1, 2, 1, 2 });
        }

        [Test]
        public void indexintoarray_left_1467462_2()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "x", new object[] { 1, 2, 1, 2 });
        }

        [Test]
        public void indexintoarray_left_1467462_3()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "x", new object[] { 1, 2, 1, 2 });
        }

        [Test]
        public void indexintoarray_left_1467462_4()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "x", new object[] { true, false, true, true });
        }

        [Test]
        public void indexintoarray_left_1467462_5()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "x", new object[] { 1, false, true, 2 });
        }

        [Test]
        public void indexintoarray_left_1467462_6()
        {
            string code =
                @"
            string str = "DNL-1467475 Regression : Dot Operation using Replication on heterogenous array of instances is yielding wrong output";
            var mirror = thisTest.VerifyRunScriptSource(code, str);
            TestFrameWork.Verify(mirror, "y", new object[] { 1, 1, 2, 2 });
        }

        [Test]
        public void indexintoarray_left_1467462_7()
        {
            string code =
                @"
            var mirror = thisTest.RunScriptSource(code);
            TestFrameWork.Verify(mirror, "y", new object[] { 1, 1, null, null });
        }

        [Test]
        public void TS200_memberproperty_1467486_1()
        {
            string code =
                @"
            string error = "1467486 if a member property is defined as variable array then while assigning value itthrows error could not decide which function to execute";
            var mirror = thisTest.VerifyRunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "y", new object[] { 1.5, 2.5 });
            thisTest.VerifyRuntimeWarningCount(0);
        }

        [Test]
        public void TS201_memberproperty_1467486_2()
        {
            string code =
                @"

            string error = "1467486 if a member property is defined as variable array then while assigning value itthrows error could not decide which function to execute";
            var mirror = thisTest.VerifyRunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "y", new object[] { 1, 2 });
            //thisTest.VerifyRuntimeWarning(ProtoCore.RuntimeData.WarningID.kAmbiguousMethodDispatch); 
            thisTest.VerifyRuntimeWarningCount(0);
        }

        [Test]
        public void TS202_memberproperty_1467486_3()
        {
            string code =
                @"
            string error = "1467486 if a member property is defined as variable array then while assigning value itthrows error could not decide which function to execute";
            var mirror = thisTest.VerifyRunScriptSource(code, error);
            TestFrameWork.Verify(mirror, "b", new object[] { 1, 1 });
            thisTest.VerifyRuntimeWarningCount(0);
        }
    }
}
