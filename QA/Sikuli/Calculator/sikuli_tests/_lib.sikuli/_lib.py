from sikuli import *
import HTMLTestRunner
bdLibPath = os.path.abspath(sys.argv[0] + "..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _uimap import *

def OpenApplication(appName, options = ""):
    __default_SleepTime = 0.5

    sleep(__default_SleepTime)
    type("d", KEY_WIN); sleep(__default_SleepTime)
    type("r", KEY_WIN); sleep(__default_SleepTime)
    type(appName + " " + options); sleep(__default_SleepTime)
    type(Key.ENTER)

def OpenCalculator():
    OpenApplication("calc")
    wait(Calculator.body_Calculator, global_WaitTime)

def ClickOrTypeNumber(number):
    if exists(number):
        click(number)
    else:
        type(number)

def Calculate(firstNumber, secondNumber, operationButton):
    click(Calculator.button_Clear)
    ClickOrTypeNumber(firstNumber)
    click(operationButton)
    ClickOrTypeNumber(secondNumber)
    click(Calculator.button_Equals)

def Add(firstNumber, secondNumber):
    Calculate(firstNumber, secondNumber, Calculator.button_Add)

def Multiply(firstNumber, secondNumber):
    Calculate(firstNumber, secondNumber, Calculator.button_Multiply)

def Subtract(firstNumber, secondNumber):
    Calculate(firstNumber, secondNumber, Calculator.button_Subtract)

def Divide(firstNumber, secondNumber):
    Calculate(firstNumber, secondNumber, Calculator.button_Divide)

def CheckResult(expected):
    click(Calculator.button_Edit)
    click(Calculator.button_Copy)
    result = Env.getClipboard().strip() #assign contents of clipboard to a variable
    assert result == expected
