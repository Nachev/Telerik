########################################################
# UI map for Calculator
########################################################
from sikuli import *
########################################################

global_WaitTime = 20
  
class Calculator:
    body_Calculator = Pattern("body_Calculator.png").similar(0.50)
    button_Two = "button_Two.png"
    button_Three = "button_Three.png"
    button_Edit = "button_Edit.png"
    button_Copy = Pattern("button_Copy.png").targetOffset(-54,0)
    button_Clear = "button_Clear.png"
    button_Add = "button_Add.png"
    button_Subtract = "button_Subtract.png"
    button_Multiply = "button_Multiply.png"
    button_Divide = "button_Divide.png"
    button_Equals = "button_Equals.png"