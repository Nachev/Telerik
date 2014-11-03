import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class SendSkypeMessage(unittest.TestCase):
    __defaultWaitTime = 30
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass    
    
    def test_001_OpenSkype(self):
        OpenSkype()

    def test_002_SendMessage(self):
        SendSkypeMessageTo("Telerik QA Academy 2014", "Test message")
        DeleteLastMessage()
             
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SendSkypeMessage)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='SendSkypeMessage Report')
    runner.run(suite)
    outfile.close()

