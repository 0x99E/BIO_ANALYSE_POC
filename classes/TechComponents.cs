using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.classes
{
    public class TechComponent
    {
        public abstract class AComponent
        {
            bool exist;
        }

        public abstract class AScaner
        {
            abstract public string getOrganType(Biology.AOrgan organ);
            abstract public string me();
            abstract public string scan(Biology.AOrgan organ);
            abstract public bool isError(string stringToCheck);
        }

        public class Scaner : AScaner
        {
           
            protected string name;

            public string errorCode = helper.getSHA256("error");
            public override string getOrganType(Biology.AOrgan organ)
            {
                return organ.GetType().Name;
            }

            public override string scan(Biology.AOrgan organ)
            {
                return errorCode;
            }

            public override string me()
            {
                return name;
            }

            public override bool isError(string stringToCheck)
            {
                return helper.getSHA256(stringToCheck) == errorCode;
            }


        }

        public class EyeScanner : Scaner
        {

            public EyeScanner()
            {
                name = "EyeScanner";
            }
            public string scan(Biology.Eye organ)
            {
                var response = "";
                string parameters = "";
                if (organ.Exist)
                {
                    parameters = organ.Color + "|" + organ.Splash;  
                }
                else
                {
                    parameters = "error";              
                }
                
                response = helper.getSHA256(parameters);
                return response;
            }


            
        }

        public class MuscleScanner : Scaner
        {
            public MuscleScanner()
            {
                name = "MuscleScanner";
            }
            public string scan(Biology.Muscle organ)
            {
                var response = "";
                string parameters = "";
                if (organ.Exist)
                {
                    parameters = organ.FiberNumber + "|" + organ.FatNumber;
                }
                else
                {
                    parameters = "error";
                }

                response = helper.getSHA256(parameters);
                return response;
            }
        }

        public class BodyPartScanner : Scaner
        {
            public BodyPartScanner()
            {
                name = "BodyPartScanner";
            }

            public string scan(Biology.BodyPart organ)
            {
                var response = "";
                string parameters = "";
                if (organ.Exist)
                {
                    parameters = organ.Fingerprint + "|" + organ.GetType().Name;
                }
                else
                {
                    parameters = "error";
                }

                response = helper.getSHA256(parameters);
                return response;
            }

        }
        
        public class UniversalScanner : Scaner
        {
            public UniversalScanner()
            {
                name = "UniversalScanner";
            }
            
            override public string scan(Biology.AOrgan organ)
            {
                var response = "";
                string parameters = "";
                if (organ.Exist)
                {
                    parameters = organ.Parameter;
                }
                else
                {
                    parameters = "error";
                }
                response = helper.getSHA256(parameters);
                return response;
            }            
        }

        

    }
}
