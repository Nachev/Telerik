import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class CalculatorTest(unittest.TestCase):
    __defaultWaitTime = 30
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass    
    
    def test_001_OpenCalculator(self):
        OpenCalculator()

    def test_002_Addition(self):
        Add("6", "4")
        CheckResult("10")

    def test_003_AdditionWithButtons(self):
        Add(Calculator.button_Two, Calculator.button_Three)
        CheckResult("5")

    def test_004_Multiplication(self):
        Multiply("3", "4")
        CheckResult("12")

    def test_005_Subtraction(self):
        Subtract("3", "4")
        CheckResult("-1")

    def test_006_Division(self):
        Divide("6", "2")
        CheckResult("3")

    def test_007_DivisionByZero(self):
        Divide("6", "0")
        CheckResult("Cannot divide by zero")
             
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(CalculatorTest)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='CalculatorTest Report')
    runner.run(suite)
    outfile.close()

