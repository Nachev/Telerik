import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class MinimizeAllWindows(unittest.TestCase):
    __defaultWaitTime = 30
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass    
    
    def test_001_OpenWindows(self):
        RunBrowserToUrl("firefox", "http://platform.telerik.com", " -new-window")
        RunBrowserToUrl("firefox", "http://google.com", " -new-window")
        RunBrowserToUrl("firefox", "http://telerikacademy.com", " -new-window")
        wait(Browser.title_TelerikAcademy, MinimizeAllWindows.__defaultWaitTime)

    def test_002_MinimizeWindows(self):
        while exists(Browser.button_Minimize):
            click(Browser.button_Minimize)
            pass
             
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(MinimizeAllWindows)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='MinimizeAllWindows Report' )
    runner.run(suite)
    outfile.close()

