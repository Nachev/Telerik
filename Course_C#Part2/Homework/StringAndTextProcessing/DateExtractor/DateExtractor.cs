namespace DateExtractor
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /*Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
     * Display them in the standard date format for Canada.*/

    public class DateExtractor
    {
        private const string SampleText = "Upon the outbreak of World War II, the government of the Kingdom of Bulgaria under Bogdan Filov declared a position of neutrality, being determined to observe it until the end of the war, but hoping for bloodless territorial gains, especially in the lands with a significant Bulgarian population occupied by neighbouring countries after the Second Balkan War and World War I.But it was clear that the central geopolitical position of Bulgaria in the Balkans would inevitably lead to strong external pressure by both sides of World War II. Turkey had a non-aggression pact with Bulgaria. Bulgaria succeeded in negotiating a recovery of Southern Dobruja, part of Romania since 1913, in the Axis-sponsored Treaty of Craiova on 7.11.1940, which reinforced Bulgarian hopes for solving territorial problems without direct involvement in the war. However, Bulgaria was forced to join the Axis powers in 1941, when German troops that were preparing to invade Greece from Romania reached the Bulgarian borders and demanded permission to pass through Bulgarian territory. Test - 32.01.34 Threatened by direct military confrontation, Tsar Boris III had no choice but to join the fascist bloc, which was made official on 1.03.1941. There was little popular opposition, since the Soviet Union was in a non-aggression pact with Germany. However the king refused to hand over the Bulgarian Jews to the Nazis, saving 50,000 lives. Bulgarian troops marching at a victory parade in Sofia celebrating the end of World War II, 1945 Bulgaria did not join the German invasion of the Soviet Union that began on 22.06.1941 nor did it declare war on the Soviet Union. However, despite the lack of official declarations of war by both sides, the Bulgarian Navy was involved in a number of skirmishes with the Soviet Black Sea Fleet, which attacked Bulgarian shipping at 65.54.1854. Besides this, Bulgarian armed forces garrisoned in the Balkans battled various resistance groups. The Bulgarian government was forced by Germany to declare a token war on the United Kingdom and the United States on 13.12.1941, an act which resulted in the bombing of Sofia and other Bulgarian cities by Allied aircraft. On 23.08.1944, Romania left the Axis Powers and declared war on Germany, and allowed Soviet forces to cross its territory to reach Bulgaria. On 5.11.1944 the Soviet Union declared war on Bulgaria and invaded. Within three days, the Soviets occupied the northeastern part of Bulgaria along with the key port cities of Varna and Burgas. Meanwhile, on 5 of September, Bulgaria declared war on Nazi Germany. The Bulgarian Army was ordered to offer no resistance. On 9.11.1944 in a coup the government of Prime Minister Konstantin Muraviev was overthrown and replaced with a government of the Fatherland Front led by Kimon Georgiev. On 16.11.1944.54 the Soviet Red Army entered Sofia. The Bulgarian Army marked several victories against the 7th SS Volunteer Mountain Division Prinz Eugen (at Nish), the 22nd Infantry Division (at Strumica) and other German forces during the operations in Kosovo and at Stratsin.";

        private static void Main()
        {
            string inputText = SampleText;
            string regex = @"(\b[0-9]?[0-9]\.[0-9]?[0-9]\.[0-9]{4}\b)";

            MatchCollection match = Regex.Matches(inputText, regex);
            foreach (var date in match)
            {        
                DateTime tempDate = new DateTime();
                bool isCorrectDate = DateTime.TryParse(date.ToString(),out tempDate);
                if (isCorrectDate)
                {
                    Console.WriteLine(tempDate.Date.ToString("d", CultureInfo.CreateSpecificCulture("en-CA")));
                }
            }
        }
    }
}
