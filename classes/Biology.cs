using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.classes
{
    public class Biology
    {

        public abstract class AOrgan
        {
            protected bool exist;
            public bool Exist
            {
                get { return exist; }
                set { exist = value; }
            }
            protected string idParameter;
            public string Parameter
            {
                get { return idParameter; }
                
            }
        }

        public class Muscle : AOrgan
        {
            private int fiberNumber;
            private int fatNumber;
            public int FiberNumber
            {
                get { return fiberNumber; }
            }
            public int FatNumber
            {
                get { return fatNumber; }
            }

            public Muscle(bool exist = true)

            {

                // Randomize fiber and fat number
                fiberNumber = new Random().Next(1, 200);
                fatNumber = new Random().Next(1, 200);
                this.exist = exist;
                idParameter = fiberNumber + "|" + fatNumber;

            }

            public Muscle(int fiberNumber, int fatNumber)
            {
                this.fiberNumber = fiberNumber;
                this.fatNumber = fatNumber;
                this.exist = true;
                idParameter = fiberNumber + "|" + fatNumber;
            }


    }

        public class Eye : AOrgan
        {
            public string color;
            public string splash;
            // Get Property for color and splash
            public string Color
            {
                get { return color; }
            }
            public string Splash
            {
                get { return splash; }
            }

            public Eye(string color, string splash, bool exist = true)
            {
                this.color = color;
                this.splash = splash;
                this.exist = exist;
                idParameter = color + "|" + splash;

            }
            public Eye(bool exist = true)
            {
                color = classes.helper.randomString(5);
                splash = classes.helper.randomString(5);
                this.exist = exist;
                idParameter = color + "|" + splash;
                
            }


        }

        public class BodyPart : AOrgan
        {
            protected string fingerprint;
            // Get property for fingerprint
            public string Fingerprint
            {
                get { return fingerprint; }
            }

            public BodyPart()
            {
                fingerprint = classes.helper.randomString(10);
                this.exist = true;
                idParameter = fingerprint;


            }
            public BodyPart(bool exist = true)
            {
                fingerprint = classes.helper.randomString(10);
                this.exist = exist;
                idParameter = fingerprint;
                

            }
            public BodyPart(string fingerprint)
            {
                this.fingerprint = fingerprint;
                this.exist = true;
                idParameter = fingerprint;
                
            }

        }

        public class Leg : BodyPart
        {

            public Leg() : base(){
                fingerprint = classes.helper.randomString(10);
                this.exist = true;
                idParameter = fingerprint;

            }

            public Leg(string fingerprint) : base()
            {
                this.fingerprint = fingerprint;
                this.exist = true;
                idParameter = fingerprint;

            }

            public Leg(bool exist = true) : base(exist)
            {
                fingerprint = classes.helper.randomString(10);
                this.exist = exist;
                idParameter = fingerprint;


            }

        }

        public class Hand : BodyPart
        {
            public Hand() : base() 
            {
                fingerprint = classes.helper.randomString(10);
                this.exist = true;
                idParameter = fingerprint;

            }

            public Hand(string fingerprint) : base(fingerprint)
            {
                this.fingerprint = fingerprint;
                this.exist = true;
                idParameter = fingerprint;

            }

            public Hand(bool exist = true) : base(exist)
            {
                fingerprint = classes.helper.randomString(10);
                this.exist = exist;
                idParameter = fingerprint;


            }

        }

        public class Head 
        {
            private Eye leftEye;
            private Eye rightEye;
            private Muscle muscle;
            // Get property for leftEye and rightEye and muscle
            public Eye LeftEye
            {
                get { return leftEye; }
            }
            public Eye RightEye
            {
                get { return rightEye; }
            }
            public Muscle Muscle
            {
                get { return muscle; }
            }
            
            public Head()
            {
                leftEye = new Eye();
                rightEye = new Eye();
                muscle = new Muscle();
            }

            public Head(Eye leftEye, Eye rightEye, Muscle muscle)
            {
                this.leftEye = leftEye;
                this.rightEye = rightEye;
                this.muscle = muscle;
            }
            

        }

        public class Body
        {
            private Hand leftHand;
            private Hand rightHand;
            private Leg leftLeg;
            private Leg rightLeg;
            private Muscle muscle;
            // Get property for leftHand, rightHand, leftLeg and rightLeg
            public Hand LeftHand
            {
                get { return leftHand; }
            }
            public Hand RightHand
            {
                get { return rightHand; }
            }
            public Leg LeftLeg
            {
                get { return leftLeg; }
            }
            public Leg RightLeg
            {
                get { return rightLeg; }
            }
            public Muscle Muscle
            {
                get { return muscle; }
            }
            public Body()
            {
                leftHand = new Hand();
                rightHand = new Hand();
                leftLeg = new Leg();
                rightLeg = new Leg();
                muscle = new Muscle();
            }
            public Body(Hand leftHand, Hand rightHand, Leg leftLeg, Leg rightLeg, Muscle muscle)
            {
                this.leftHand = leftHand;
                this.rightHand = rightHand;
                this.leftLeg = leftLeg;
                this.rightLeg = rightLeg;
                this.muscle = muscle;
            }
        }

        public class Human
        {
            protected string name;
            private Head head;
            private Body body;

            // Get property for name, head and body

            public string Name
            {
                get { return name; }
            }
            public Head Head
            {
                get { return head; }
            }
            public Body Body
            {
                get { return body; }
            }

            public Human()
            {
                this.name = classes.helper.randomString(10);
                this.head = new Head();
                this.body = new Body();
            }

            public Human(string name)
            {
                this.name = name;
                this.head = new Head();
                this.body = new Body();
            }

            public Human(string name, Head head, Body body)
            {
                this.name = name;
                this.head = head;
                this.body = body;
            }

        }
        
    }

}
