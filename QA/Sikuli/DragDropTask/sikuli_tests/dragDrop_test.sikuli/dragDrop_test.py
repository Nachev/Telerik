import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class DragDropTests(unittest.TestCase):
    __defaultWaitTime = 30
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass    
    
    def test_001_NavigateToHtmlGoodies(self):
        RunBrowserToUrl("chrome","http://www.dhtmlgoodies.com/scripts/drag-drop-custom/demo-drag-drop-3.html")
        wait(HtmlGoodies.title_DragDrop, DragDropTests.__defaultWaitTime)
    
    def test_002_DragCapitolsToCountries(self):
        dragDrop(HtmlGoodies.draggable_Washington, HtmlGoodies.droppable_UnitedStates)
        dragDrop(HtmlGoodies.draggable_Oslo, HtmlGoodies.droppable_Norway)
        dragDrop(HtmlGoodies.draggable_Stockholm, HtmlGoodies.droppable_Sweden)
        dragDrop(HtmlGoodies.draggable_Copenhagen, HtmlGoodies.droppable_Denmark)
        dragDrop(HtmlGoodies.draggable_Seoul, HtmlGoodies.droppable_SouthKorea)
        dragDrop(HtmlGoodies.draggable_Rome, HtmlGoodies.droppable_Italy)
        dragDrop(HtmlGoodies.draggable_Madrid, HtmlGoodies.droppable_Spain)
        wait(HtmlGoodies.verification_AllSet)

if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(DragDropTests)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='DragDropTests Report' )
    runner.run(suite)
    outfile.close()