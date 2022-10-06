using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;

namespace LAB_6.classes
{
    partial class Circuit
    {
        class Analyser
        {

            private TechComponent.Scaner scannerModule;

            public Analyser()
            {
                scannerModule = new TechComponent.UniversalScanner();
            }

            public string getOrganFinderprint(Biology.AOrgan organ)
            {
                string response = "";
                response = scannerModule.scan(organ);
                if (scannerModule.isError(response))
                {
                    response = "0";
                }
                return response;
            }

            public string getOrganAnalysis(Biology.AOrgan organ)
            {
                string response = "";
                string responseFingerprint = scannerModule.scan(organ);
                string organType = scannerModule.getOrganType(organ);
                if (scannerModule.isError(response))
                {
                    response = "0";
                }
                else
                {
                    response = organType + "|" + responseFingerprint;

                }

                return response;
            }


            public string getHeadFingerprint(Biology.Head head)
            {
                string response = "";
                Biology.Eye lefteye = head.LeftEye;
                Biology.Eye rightEye = head.RightEye;
                Biology.Muscle muscle = head.Muscle;

                response += getOrganFinderprint(lefteye);
                response += getOrganFinderprint(rightEye);
                response += getOrganFinderprint(muscle);

                response = helper.getSHA256(response);
                return response;
            }

            public string getHeadAnalysis(Biology.Head head)
            {
                string response = "";
                Biology.Eye lefteye = head.LeftEye;
                Biology.Eye rightEye = head.RightEye;
                Biology.Muscle muscle = head.Muscle;

                response += "Head:" + "\n";
                response += getOrganAnalysis(lefteye) + "\n";
                response += getOrganAnalysis(rightEye) + "\n";
                response += getOrganAnalysis(muscle);

                return response;
            }


            public string getBodyFingerprint(Biology.Body body)
            {
                string response = "";
                Biology.Hand leftHand = body.LeftHand;
                Biology.Hand rightHand = body.RightHand;
                Biology.Muscle muscle = body.Muscle;

                response += getOrganFinderprint(leftHand);
                response += getOrganFinderprint(rightHand);
                response += getOrganFinderprint(muscle);

                response = helper.getSHA256(response);
                return response;
            }

            public string getBodyAnalysis(Biology.Body body)
            {
                string response = "";
                Biology.Hand leftHand = body.LeftHand;
                Biology.Hand rightHand = body.RightHand;
                Biology.Muscle muscle = body.Muscle;

                response += "Body:" + "\n";
                response += getOrganAnalysis(leftHand) + "\n";
                response += getOrganAnalysis(rightHand) + "\n";
                response += getOrganAnalysis(muscle);

                return response;
            }

            public string getHumanFingerprint(Biology.Human human)
            {
                string response = "";
                Biology.Body body = human.Body;
                Biology.Head head = human.Head;

                response += getBodyFingerprint(body);
                response += getHeadFingerprint(head);

                response = helper.getSHA256(response);
                return response;
            }

            public string getHumanAnalysis(Biology.Human human)
            {
                string response = "";
                Biology.Head head = human.Head;
                Biology.Body body = human.Body;

                response += "Name: " + human.Name + "\n";
                response += getHeadAnalysis(head) + "\n";
                response += getBodyAnalysis(body) + "\n";

                return response;
            }


        }

        class IOModule
        {
            private string prefix = "";

            // Property for prefix
            public string Prefix
            {
                get { return prefix; }
            }

            public IOModule()
            {
                
            }

            public IOModule(string prefix)
            {
                this.prefix = prefix;
            }


            public string input() 
            {
                Console.Write("{0}Input: ", prefix);
                string userInput = Console.ReadLine();
                return userInput;

            }


            public int safeInput()
            {
                int result = 0;
                bool success = false;
                do
                {
                    try
                    {
                        this.output("Enter int:");
                        string input = this.input();
                        result = int.Parse(input);
                        success = true;
                    }
                    catch (Exception)
                    {

                    }
                } while (!success);

                return result;

            }


            public void output(string message)
            {
                string messageToPrint = prefix + message;
                Console.WriteLine(messageToPrint);
            }

            public void changePrefix(string newPrefix)
            {
                // Set new Prefix 
                prefix = newPrefix;
            }

        }

        class Firewall
        {
            private string password = "24102003";
            private bool unlocked = false;

            public Firewall()
            {

            }

            private void sleep(int seconds)
            {
                int miliseconds = seconds * 1000;
                Thread.Sleep(miliseconds);
            }
            
            public bool changePassword(string oldPassword, string newPassword)
            {
                bool result = false;
                if (oldPassword == password)
                {
                    password = newPassword;
                    result = true;
                }
                else
                {
                    sleep(5);
                    result = false;
                }
                
                return result;
            }

            public bool unlock(string password)
            {
                bool result = false;
                if (password == this.password)
                {
                    unlocked = true;
                    result = true;
                }
                else
                {
                    sleep(3);
                    unlocked = false;
                    result = false;
                }
                return result;
            }

            public void block()
            {
                unlocked = false;
            }
             
            public bool isUnlocked()
             {
                return unlocked;
             }
        }
        
        class Creator
        {
            private IOModule io;

            public Creator(IOModule iomodule)
            {
                this.io = iomodule;
            }

            public Biology.Human createHuman()
            {

                Biology.Human newHuman;
                Biology.Head head;
                Biology.Eye leftEye;
                Biology.Eye rightEye;
                Biology.Muscle headMuscle;

                Biology.Body body;
                Biology.Hand leftHand;
                Biology.Hand rightHand;
                Biology.Leg leftLeg;
                Biology.Leg rightLeg;
                Biology.Muscle bodyMuscle;

                io.output("Enter name:");
                string name = io.input();

                io.output("Enter leftEye color:");
                string leftEyeColor = io.input();

                io.output("Enter leftEye splash:");
                string leftEyeSplash = io.input();

                io.output("Enter rightEye splash:");
                string rightEyeColor = io.input();

                io.output("Enter rightEye splash:");
                string rightEyeSplash = io.input();

                io.output("Enter headMuscle fiberNumber:");
                int headMuscleFiber = io.safeInput();

                io.output("Enter headMuscle fatNumber:");
                int headMuscleFat = io.safeInput();




                io.output("Left leg exists? [yes/no]");
                string leftLegAnswer = io.input();
                bool leftLegExist = (leftLegAnswer.ToLower() == "yes");
                string leftLegFingerprint = "";
                if (leftLegExist)
                {
                    io.output("Enter left leg fingerprint or left empty:");
                    leftLegFingerprint = io.input();

                }

                io.output("Right leg exists? [yes/no]");
                string rightLegAnswer = io.input();
                bool rightLegExist = (rightLegAnswer.ToLower() == "yes");
                string rightLegFingerprint = "";
                if (rightLegExist)
                {
                    io.output("Enter right leg fingerprint or left empty:");
                    rightLegFingerprint = io.input();

                }


                io.output("Left hand exists? [yes/no]");
                string leftHandAnswer = io.input();
                bool leftHandExist = (leftHandAnswer.ToLower() == "yes");
                string leftHandFingerprint = "";
                if (leftHandExist)
                {
                    io.output("Enter left hand fingerprint or left empty:");
                    leftHandFingerprint = io.input();

                }

                io.output("Right hand exists? [yes/no]");
                string rightHandAnswer = io.input();
                bool rightHandExist = (rightHandAnswer.ToLower() == "yes");
                string rightHandFingerprint = "";
                if (leftHandExist)
                {
                    io.output("Enter right hand fingerprint or left empty:");
                    rightHandFingerprint = io.input();

                }



                io.output("Enter bodyMuscle fiberNumber:");
                int bodyMuscleFiber = io.safeInput();

                io.output("Enter bodyMuscle fatNumber:");
                int bodyMuscleFat = io.safeInput();

                // Creating head
                leftEye = new Biology.Eye(leftEyeColor, leftEyeSplash);
                rightEye = new Biology.Eye(rightEyeColor, rightEyeSplash);
                headMuscle = new Biology.Muscle(headMuscleFiber, headMuscleFat);
                head = new Biology.Head(leftEye, rightEye, headMuscle);

                //Creating body
                //Left Hand
                if (leftHandExist)
                {
                    leftHand = new Biology.Hand(leftHandFingerprint);
                }
                else
                {
                    leftHand = new Biology.Hand(false);

                }
                //Right Hand
                if (rightHandExist)
                {
                    rightHand = new Biology.Hand(rightHandFingerprint);
                }
                else
                {
                    rightHand = new Biology.Hand(false);

                }
                // Muscle
                bodyMuscle = new Biology.Muscle(bodyMuscleFiber, bodyMuscleFat);

                //Left Leg
                if (leftHandExist)
                {
                    leftLeg = new Biology.Leg(leftLegFingerprint);
                }
                else
                {
                    leftLeg = new Biology.Leg(false);

                }
                //Right Leg
                if (rightLegExist)
                {
                    rightLeg = new Biology.Leg(rightLegFingerprint);
                }
                else
                {
                    rightLeg = new Biology.Leg(false);

                }
                body = new Biology.Body(leftHand, rightHand, leftLeg, rightLeg, bodyMuscle);

                
                newHuman = new Biology.Human(name, head, body);
                return newHuman;
            }

            public Biology.Human cloneHuman(Biology.Human source)
            {
                Biology.Human newHuman;

                io.output("Enter name:");
                string name = io.input();

                Biology.Head sourceHead = source.Head;
                Biology.Body sourceBody = source.Body;

                newHuman = new Biology.Human(name, sourceHead, sourceBody);

                return newHuman;

            }

            public Biology.Human newHuman()
            {
                Biology.Human newHuman;

                newHuman = new Biology.Human();

                return newHuman;

            }

           

        }

        class Reporter
        {
            IOModule io;
            private string path;
            private string basePath = Directory.GetCurrentDirectory();
            private string fullPath;
            public Reporter(IOModule io)
            {
                this.io = io;
                path = $@"\reports\";
                fullPath = basePath + path;
                onStartup();
            }

            public Reporter(IOModule io, string name)
            {
                this.io = io;
                path = $@"\{name}\";
                fullPath = basePath + path;
                onStartup();
            }

            private void onStartup()
            {
                System.IO.Directory.CreateDirectory(fullPath);
            }
            private string getFile(string name)
            {
                string filePath = fullPath + name;
                string text;

                if (File.Exists(filePath))
                {
                    text = File.ReadAllText(filePath);

                }
                else
                {
                    text = "None.";
                }

                return text;
            }

            private List<string> getFileList()
            {
                List<string> files = new List<string>();

                files.AddRange(Directory.GetFiles(fullPath, "*.txt").ToList());

                return files;
            }
            
            private void saveFile(string name, string content)
            {
                string filePath = fullPath + name;
                File.WriteAllText(filePath, content);
            }

            public void saveReport(string name, string content)
            {
                name += ".txt";
                saveFile(name, content);

            }
        
            public void listReport()
            {
                List<string> files = getFileList();
                int index = 0;
                int filesNumber = files.Count;
                string generalInfo = $"REPORT [{filesNumber}]";
                io.output(generalInfo);

                foreach (string file in files)
                {
                    io.output($"===[{index}]===");
                    io.output($"{file}\n");
                    index++;
                }
            }
        
            public void showReport(string name)
            {
                name += ".txt";
                string content = getFile(name);
                io.output($"REPORT [{name}]\n");
                io.output(content);
            }

        }

        public partial class Comander
        {
            private string name = "BIOCOMMANDO";
            private string startUpMessage = "Welcome to the Bio-Analyser!\n";
            private int cmdExecuted = 0;

            private IOModule io;
            private Analyser analyser;
            private Firewall firewall;
            private Creator creator;
            private Reporter reporter;

            private List<Biology.Human> knownHumanList = new List<Biology.Human>();
            private List<string> cmdList = new List<string>();


            public Comander()
            {
                io = new IOModule();
                analyser = new Analyser();
                firewall = new Firewall();
                creator = new Creator(io);
                reporter = new Reporter(io);
                onStart();
                
            }

            public Comander(string startUpMessage)
            {
                io = new IOModule();
                analyser = new Analyser();
                firewall = new Firewall();
                creator = new Creator(io);
                reporter = new Reporter(io);

                this.startUpMessage = startUpMessage;
                onStart();
            }
            
            private void fillCmdList()
            {
                cmdList.Add("add");
                cmdList.Add("create");
                cmdList.Add("clone");
                cmdList.Add("list");
                cmdList.Add("compare");
                cmdList.Add("delete");

                cmdList.Add("status");
                cmdList.Add("prefix");
                cmdList.Add("lock");
                cmdList.Add("unlock");
                cmdList.Add("password");
                cmdList.Add("exit");

                cmdList.Add("showreport");
                cmdList.Add("savereport");
                cmdList.Add("listreport");


                cmdList.Add("help");
                cmdList.Add("time");

            }
            
            private void onStart()
            {
                fillCmdList();
                io.output(startUpMessage);
                //io.output
            }

            private string getCurrentTime()
            {
                // Get current time
                DateTime currentTime = DateTime.Now;
                string time = currentTime.ToString("HH:mm:ss");
                return time;
            }

            private string getStatus()
            {
                string status = "";
                status += name + "\n";
                status += "Unlocked: " + firewall.isUnlocked() + "\n";
                status += "KnownHuman: " + knownHumanList.Count + "\n";
                status += "CMD Executed: " + cmdExecuted + "\n";


                return status;

            }
           




            private bool executor(string cmd)
            {
                bool running = true;
                cmdExecuted++;
                string message = "";
                string tempField = "";
                string reportName = "";

                Biology.Human tempHuman;
                bool logged = firewall.isUnlocked();
                switch (cmd)
                {

                    case "showreport":
                        if (logged)
                        {
                            io.output("Enter name of report: ");
                            reportName = io.input();
                            reporter.showReport(reportName);
                            io.output("Success!");

                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "listreport":
                        if (logged)
                        {
                            reporter.listReport();
                            io.output("Success!");

                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "savereport":
                        if (logged)
                        {
                            io.output("Enter index of human to be saved: ");
                            int indexToReport = io.safeInput();

                            io.output("Enter report name: ");
                            string reportNameToSave = io.input();
                            if ((knownHumanList.Count - 1) >= indexToReport)
                            {
                                tempField = analyser.getHumanAnalysis(knownHumanList[indexToReport]);
                                reporter.saveReport(reportNameToSave, tempField);

                            }else{
                                io.output("Wrong index!");
                            }
                            io.output("Success!");
                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;


                    case "add":
                        if (logged)
                        {
                            tempHuman = creator.newHuman();
                            knownHumanList.Add(tempHuman);
                            io.output("Success!");

                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;


                    case "create":
                        if (logged)
                        {
                            tempHuman = creator.createHuman();
                            knownHumanList.Add(tempHuman);
                            io.output("Success!");

                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "clone":
                        if (logged)
                        {
                            
                            io.output("Enter index: ");
                            int indexToInfo = io.safeInput();
                            if ((knownHumanList.Count - 1) >= indexToInfo)
                            {
                                tempHuman = knownHumanList[indexToInfo];
                                Biology.Human clonedHuman = creator.cloneHuman(tempHuman);
                                knownHumanList.Add(clonedHuman);
                                io.output("Success!");

                            }
                            {
                                io.output("Wrong index");
                            }
                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "compare":
                        if (logged)
                        {
                            io.output("Enter index of first humans: ");
                            int firstIndex = io.safeInput();
                            if ((knownHumanList.Count - 1) >= firstIndex)
                            {
                                io.output("Ok!");

                            }else
                            {
                                io.output("Wrong index");
                            }
                            io.output("Enter index of first humans: ");
                            int secondIndex = io.safeInput();
                            if ((knownHumanList.Count - 1) >= secondIndex)
                            {
                                io.output("Ok!");

                            }
                            else
                            {
                                io.output("Wrong index");
                            }
                            string firstFingerprint = "";
                            string secondFingerprint = "";
                            firstFingerprint = analyser.getHumanFingerprint(knownHumanList[firstIndex]);
                            secondFingerprint = analyser.getHumanFingerprint(knownHumanList[secondIndex]);
                            if (firstFingerprint == secondFingerprint)
                            {
                                io.output("They are equal! Be safe, they may be clonned)");
                            }
                            else
                            {
                                io.output("They are totally different!");

                            }

                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "list":
                        if (logged)
                        {
                            tempField += $"HUMAN LIST[{knownHumanList.Count}]:\n";
                            int humanIndex = 0;
                            foreach (Biology.Human human in knownHumanList)
                            {
                                tempField += $"===[{humanIndex}]===";
                                tempField += "\n";
                                tempField += analyser.getHumanAnalysis(human);
                                tempField += analyser.getHumanFingerprint(human);
                                tempField += "\n\n";
                                humanIndex++;

                            }

                            io.output(tempField);

                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "info":
                        if (logged)
                        {
                            io.output("Enter index: ");
                            int indexToInfo = io.safeInput();
                            if ((knownHumanList.Count - 1) >= indexToInfo)
                            {
                                tempHuman = knownHumanList[indexToInfo];
                                tempField = analyser.getHumanAnalysis(tempHuman);
                                io.output(tempField);
                            }
                            {
                                io.output("Wrong index");
                            }
                            
                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "delete":
                        if (logged)
                        {
                            io.output("Enter index: ");
                            int indexToDelete = io.safeInput();
                            if ((knownHumanList.Count - 1) >= indexToDelete)
                            {
                                knownHumanList.RemoveAt(indexToDelete);

                            }
                            io.output("Deleted successfully!");
                        }
                        else
                        {
                            io.output("Please login!");
                        }
                        break;

                    case "status":
                        message = getStatus() + getCurrentTime();
                        io.output(message);
                        break;

                    case "prefix":
                        if (logged)
                        {
                            io.output("Enter new prefix:");
                            tempField = io.input();
                            io.changePrefix(tempField);
                        }
                        else
                        {
                            io.output("Please login!");

                        }
                        break;

                    case "lock":
                        firewall.block();
                        break;

                    case "unlock":
                        if (logged)
                        {
                            io.output("Allready unlocked!");
                        }
                        else
                        {
                            io.output("Please enter pass:");
                            tempField = io.input();
                            firewall.unlock(tempField);
                            if (firewall.isUnlocked())
                            {
                                io.output("Success!");
                            }
                            else
                            {
                                io.output("Wrong pass!");
                            }
                        }
                        break;


                    case "password":
                        if (logged)
                        {
                            io.output("Enter current password:");
                            string oldPassword = io.input();

                            io.output("Enter new password:");
                            string newPassword = io.input();
                            bool status = firewall.changePassword(oldPassword, newPassword);
                            if (status)
                            {
                                io.output("Successfuly changed!");
                            }
                            else
                            {
                                io.output("Wrong old password");
                            }
                        }
                        else
                        {
                            io.output("Please login!");

                        }
                        break;


                    case "exit":
                        running = false;
                        break;

                    case "help":
                        int cmdIndex = 0;
                        tempField += $"CMD LIST [{cmdList.Count}]\n";
                        foreach (string smallCmd in cmdList)
                        {
                            tempField += $" {cmdIndex}) {smallCmd}\n";
                            cmdIndex++;
                        }
                        io.output(tempField);
                        break;

                    case "time":
                        tempField = getCurrentTime();
                        io.output(tempField);
                        break;

                    default:
                        io.output("INVALID INPUT!");
                        io.output("Type help.");
                        break;
                }


                return running;
            }
            
            private bool poller()
            {
                bool running = false;
                string cmd;
                io.output("Enter command: ");
                cmd = io.input();

                running = executor(cmd);

                return running;
            }

            public void run()
            {
                bool running;
                do
                {
                    running = poller();
                } while (running);
                
            }

            
        }
    
    }

    
}
