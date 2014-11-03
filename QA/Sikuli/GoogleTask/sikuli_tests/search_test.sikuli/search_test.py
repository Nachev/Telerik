import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class SearchTest(unittest.TestCase):
    __defaultWaitTime = 30
    
    def setUp(self):
        Settings.OcrTextSearch = True
    
    def tearDown(self):
        pass    
    
    def test_001_NavigateToGoogle(self):
        RunBrowserToUrl("chrome","http://www.google.com")
        wait(GoogleSearch.button_GoogleSearch, SearchTest.__defaultWaitTime)
    
    def test_002_SearchForTelerikAcademy(self):
        type(GoogleSearch.button_GoogleSearch, "Telerik Academy")
        type(Key.ENTER)
        wait(GoogleSearch.area_SearchType, SearchTest.__defaultWaitTime)
        GoogleSearch.region_SearchResults.wait("Telerik Academy", SearchTest.__defaultWaitTime)
        click(GoogleSearch.button_CloseBrowser)
             
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SearchTest)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='SearchTest Report' )
    runner.run(suite)
    outfile.close()

