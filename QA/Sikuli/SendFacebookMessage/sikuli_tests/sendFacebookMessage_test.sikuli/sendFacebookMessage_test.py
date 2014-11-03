import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

    
class SendFacebookMessage(unittest.TestCase):
    __defaultWaitTime = 30
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass    
    
    def test_001_OpenSkype(self):
        OpenFacebook()

    def test_002_SendMessage(self):
        SendMessageTo("Friend", "Test message")
             
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SendFacebookMessage)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='SendFacebookMessage Report')
    runner.run(suite)
    outfile.close()

