using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace CreateImageCards
{
    internal class Program
    {
        public static int cardID;
        static void Main(string[] args)
        {

            //card Id to be able to name and create diff cards
            cardID = 0;

            CreateCardsFromList();

        }

        public static void CreateCardsFromList()
        {
            //Create List of Bitmaps
            List<Bitmap> iconBitmapList = new List<Bitmap>();
            //loop through list to add bitmaps from file to list
            List<List<string>> listOfListOfStrings = new List<List<string>>();        

            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "FourRandom", 4);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "TwoSameTwoRandom", 3);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "TwoSameOneRandom", 2);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "ThreeSame", 2);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "TwoRandom", 1);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "TwoSame", 2);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "OneIcon", 1);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "toucan", 5);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "bat", 3);
            LoopAndApplyToCard(listOfListOfStrings, iconBitmapList, "meteorite", 3);


        }

        public static void LoopAndApplyToCard(List<List<string>> listOfListOfStrings, List<Bitmap> iconBitmapList, string cardType, int loops)
        {
                for (int i = 0; i < loops; i++)
                {
                    listOfListOfStrings = GenerateLists(cardType);
                    for (int j = 0; j < listOfListOfStrings.Count; j++)
                    {
                        iconBitmapList.Clear();

                        foreach (string bitmap in listOfListOfStrings[j])
                        {

                            iconBitmapList.Add(new Bitmap(bitmap));
                        }

                        ApplyIconsToCard(iconBitmapList);
                    }
                }
        }

        public static List<List<string>> GenerateLists(string iconRatio)
        {
            //create a list to store the list of lists of strings of icons...
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create random object
            Random random = new Random();

            //get array of all files in Icon Image folder
            string[] files = Directory.GetFiles(@"C:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImages\");

            //shuffle
            files = files.OrderBy(x => random.Next()).ToArray();

            //convert to list
            List<string>shuffledFilesList = files.ToList();


            switch (iconRatio)
            {
                case "FourRandom":
                    listOfImageLists.AddRange(FourRandomIcons(shuffledFilesList));
                    break;
                case "TwoSameTwoRandom":
                    listOfImageLists.AddRange(TwoSameTwoRandomIcons(shuffledFilesList));
                    break;
                case "TwoSameOneRandom":
                    listOfImageLists.AddRange(TwoSameOneRandomIcons(shuffledFilesList));
                    break;
                case "TwoRandom":
                    listOfImageLists.AddRange(TwoRandomIcons(shuffledFilesList));
                    break ;
                case "TwoSame":
                    listOfImageLists.AddRange(TwoSameIcons(shuffledFilesList));
                    break;
                case "OneIcon":
                    listOfImageLists.AddRange(OneIcon(shuffledFilesList));
                    break;
                case "ThreeSame":
                    listOfImageLists.AddRange(ThreeSame(shuffledFilesList));
                    break;

                //if no ratio it must be special card
                default:
                    //get array of all files in Icon Image folder
                    files = Directory.GetFiles(@"C:\Users\darre\source\repos\CreateImageCards\CreateImageCards\SpecialIcons\");

                    List<string> listOfSpecialIcons = files.ToList();


                    listOfImageLists.AddRange(SpecialCard(listOfSpecialIcons, iconRatio));
                    break;
            }
                

            return listOfImageLists;
        }

        public static List<List<string>> SpecialCard(List<string> listOfIconFiles, string iconName)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOfIcons = new List<string>();

            foreach (string icon in listOfIconFiles)
            {
                if (icon.Contains(iconName))
                {
                    
                    listOfIcons.Add(icon);
                }
            }                      


            listOfImageLists.Add(listOfIcons);

            return listOfImageLists;
        }
        public static List<List<string>> OneIcon(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOfIcons = new List<string>();

            for (int i = 0; i < shuffledFilesList.Count; i++)
            {
                listOfIcons = new List<string>();

                listOfIcons.Add(shuffledFilesList[i]);
               
                listOfImageLists.Add(listOfIcons);

            }


            return listOfImageLists;
        }
                public static List<List<string>> TwoSameIcons(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOfIcons = new List<string>();

            for (int i = 0; i < shuffledFilesList.Count; i++)
            {
                listOfIcons = new List<string>();

                listOfIcons.Add(shuffledFilesList[i]);
                listOfIcons.Add(shuffledFilesList[i]);

                //shuffle list so not always in same place
                Random random = new Random();
                listOfIcons = listOfIcons.OrderBy(x => random.Next()).ToList();

                listOfImageLists.Add(listOfIcons);

            }


            return listOfImageLists;
        }
        public static List<List<string>> TwoRandomIcons(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOfIcons = new List<string>();

            for (int i = 0; i < shuffledFilesList.Count; i++)
            {
                listOfIcons = new List<string>();

                listOfIcons.Add(shuffledFilesList[i]);
                if (i + 2 >= shuffledFilesList.Count)
                {

                    listOfIcons.Add(shuffledFilesList[i + 2 - shuffledFilesList.Count]);
                }
                else
                {
                    listOfIcons.Add(shuffledFilesList[i + 2]);
                }

                //shuffle list so not always in same place
                Random random = new Random();
                listOfIcons = listOfIcons.OrderBy(x => random.Next()).ToList();

                listOfImageLists.Add(listOfIcons);

            }


            return listOfImageLists;
        }
        public static List<List<string>> TwoSameOneRandomIcons(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOf3 = new List<string>();

            for (int i = 0; i < shuffledFilesList.Count; i++)
            {
                listOf3 = new List<string>();

                listOf3.Add(shuffledFilesList[i]); 
                listOf3.Add(shuffledFilesList[i]);
                if (i + 2 >= shuffledFilesList.Count)
                {

                    listOf3.Add(shuffledFilesList[i + 2 - shuffledFilesList.Count]);
                }
                else
                {
                    listOf3.Add(shuffledFilesList[i + 2]);
                }                            

                //shuffle list so not always in same place
                Random random = new Random();
                listOf3 = listOf3.OrderBy(x => random.Next()).ToList();

                listOfImageLists.Add(listOf3);

            }


            return listOfImageLists;
        }
        public static List<List<string>> ThreeSame(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOf3 = new List<string>();

            for (int i = 0; i < shuffledFilesList.Count; i++)
            {
                listOf3 = new List<string>();

                listOf3.Add(shuffledFilesList[i]);
                listOf3.Add(shuffledFilesList[i]);
                listOf3.Add(shuffledFilesList[i]);


                //shuffle list so not always in same place
                Random random = new Random();
                listOf3 = listOf3.OrderBy(x => random.Next()).ToList();

                listOfImageLists.Add(listOf3);

            }


            return listOfImageLists;
        }
        public static List<List<string>> TwoSameTwoRandomIcons(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOf4 = new List<string>();

            for (int i = 0; i < shuffledFilesList.Count; i++)
            {
                listOf4 = new List<string>();

                listOf4.Add(shuffledFilesList[i]);                
                if (i + 2 >= shuffledFilesList.Count)
                {
                    
                    listOf4.Add(shuffledFilesList[i + 2 - shuffledFilesList.Count]);
                }
                else
                {
                    listOf4.Add(shuffledFilesList[i+2]);
                }
                listOf4.Add(shuffledFilesList[i]);
                if (i + 4 >= shuffledFilesList.Count)
                {

                    listOf4.Add(shuffledFilesList[(i + 4) - shuffledFilesList.Count]);
                }
                else
                {
                    listOf4.Add(shuffledFilesList[i + 4]);
                }

                //shuffle list so not always in same place
                Random random = new Random();
                listOf4 = listOf4.OrderBy(x => random.Next()).ToList();

                listOfImageLists.Add(listOf4);

            }

            
            return listOfImageLists;
        }
        public static List<List<string>> FourRandomIcons(List<string> shuffledFilesList)
        {
            List<List<string>> listOfImageLists = new List<List<string>>();

            //create list to add bitmaps to
            List<string> listOf4 = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                listOf4.Add(shuffledFilesList[i]);
            }

            listOfImageLists.Add(listOf4);

            listOf4 = new List<string>();
            for (int i = 4; i < shuffledFilesList.Count(); i++)
            {
                listOf4.Add(shuffledFilesList[i]);
            }

            listOfImageLists.Add(listOf4);

            return listOfImageLists;
        }

        public static void ApplyIconsToCard(List<Bitmap> bitMapList)
        {
            Bitmap blankCard;
            Graphics graphics;

            Random random = new Random();

            blankCard = CreateBlankCard(825, 1125);
            //create graphics object out of the blank card so we can draw on it
            graphics = Graphics.FromImage(blankCard);

            FillBackground(blankCard, graphics, false);


            if (bitMapList.Count == 4)
            {
                //image size for the icons
                int imageHeight = 240;
                int imageWidth = 240;



                int sizeRandomness = 50;
                int posRandomness = 10;
                int sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                int posRandAmount = random.Next(-posRandomness, posRandomness);
                graphics.DrawImage(bitMapList[0], 130 + posRandomness, 150 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                graphics.DrawImage(bitMapList[1], 400 + posRandomness, 290 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                graphics.DrawImage(bitMapList[2], 130 + posRandomness, 500 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                graphics.DrawImage(bitMapList[3], 400 + posRandomness, 700 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
            }
            if (bitMapList.Count == 3)
            {
                //image size for the icons
                int imageHeight = 280;
                int imageWidth = 280;



                int sizeRandomness = 30;
                int posRandomness = 20;
                int sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                int posRandAmount = random.Next(-posRandomness, posRandomness);
                graphics.DrawImage(bitMapList[0], 140 + posRandomness, 120 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                graphics.DrawImage(bitMapList[1], 390 + posRandomness, 400 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                graphics.DrawImage(bitMapList[2], 140 + posRandomness, 660 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                
            }
            if (bitMapList.Count == 2)
            {
                //image size for the icons
                int imageHeight = 350;
                int imageWidth = 350;

                int sizeRandomness = 30;
                int posRandomness = 20;
                int sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                int posRandAmount = random.Next(-posRandomness, posRandomness);
                graphics.DrawImage(bitMapList[0], 140 + posRandomness, 140 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                graphics.DrawImage(bitMapList[1], 320 + posRandomness, 510 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
              
            }

            

            if (bitMapList.Count == 1)
            {
                //image size for the icons
                int imageHeight = 500;
                int imageWidth = 500;

                
                int sizeRandomness = 0;
                int posRandomness = 0;
                int sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                int posRandAmount = random.Next(-posRandomness, posRandomness);
                graphics.DrawImage(bitMapList[0], 170 + posRandomness, 290 + posRandomness, imageWidth + sizeRandAmount, imageHeight + sizeRandAmount);
                sizeRandAmount = random.Next(-sizeRandomness, sizeRandomness);
                

            }


            blankCard.Save($@"C:\Users\darre\source\repos\CreateImageCards\CreateImageCards\Cards\Card-{cardID}.png");                
                
            cardID++;
        }
         
        

        public static Bitmap CreateBlankCard(int row, int col)
        {

            Bitmap blankCard = new Bitmap(row, col);

            using (Graphics grp = Graphics.FromImage(blankCard))
            {
                grp.FillRectangle(Brushes.White, 0, 0, row, col);
            }

            return blankCard;
        }

        public static void FillBackground(Bitmap blankCard, Graphics graphics, bool logoCard)
        {
            //background

            //get background texture and add it to texturebrush
            Bitmap dotTexture = new Bitmap(@"C:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\Dot Texture.jpg");
            dotTexture = new Bitmap(dotTexture, new Size(dotTexture.Width, dotTexture.Height));
            TextureBrush texBrush = new TextureBrush(dotTexture);
            //fill graphics iwht background
            graphics.FillRectangle(texBrush, new Rectangle(0, 0, blankCard.Width, blankCard.Height));
            //make opacity brush so that the texture isn't too dark
            SolidBrush opacityBrush = new SolidBrush(Color.FromArgb(240, 255, 204, 0));                         
            
            graphics.FillRectangle(opacityBrush, new Rectangle(0, 0, blankCard.Width, blankCard.Height));
        }


    }
}
