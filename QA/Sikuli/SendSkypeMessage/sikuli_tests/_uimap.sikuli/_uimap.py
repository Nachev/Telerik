########################################################
# UI map for SendSkypeMessage
########################################################
from sikuli import *
########################################################

global_WaitTime = 20

class Desktop:
    icon_SkypeQuick="icon_SkypeQuick.png"
    icon_Skype=Pattern("icon_Skype-2.png").similar(0.87)
    
class Skype:
    title_Skype="title_Skype-1.png"
    title_TelerikQAChat="title_TelerikQAChat.png"
    
    input_Search=Pattern("input_Search.png").similar(0.75)
    input_TypeMessage="input_TypeMessage.png"
    area_LastMessage=Pattern("area_LastMessage.png").targetOffset(0,-19)
    popup_ContextMenu=Pattern("popup_ContextMenu.png").targetOffset(-34,51)
    button_RemoveMessage="button_RemoveMessage.png"
    popup_RemoveMessage="popup_RemoveMessage.png"
    button_AgreeToRemove="button_Remove.png"
