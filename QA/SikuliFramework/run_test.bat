set TestRunner="C:\SikuliX\runScript.cmd"
set TestList="D:=\Git\Telerik\QA\SikuliFramework\sikuli_tests\%1.sikuli"

call %TestRunner% -r %TestList%                 

