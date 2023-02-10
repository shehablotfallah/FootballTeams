using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeams
{
    #region Team Information
    // team information
    public struct Team
    {
        public string TeamName;
        public int NumberOfWins;
        public int NumberOfDraws;
        public int NumberOfLoses;
        public int Points;
    } 
    #endregion

    class Program
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        static void PrintMessage(string message)
        {
            Console.WriteLine("*************************");
            Console.WriteLine(message);
            Console.WriteLine("*************************");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        static void PrintMessage(string message, int messageType)
        {
            if (messageType == 1)
            {
                Console.WriteLine("*************************");
                Console.WriteLine(message);
                Console.WriteLine("*************************");
            }
            else
            {
                Console.WriteLine("//////////////////////////");
                Console.WriteLine(message);
                Console.WriteLine("//////////////////////////");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static bool CheckNumber(string data, out int num)
        {
            bool bIsValidNumber = int.TryParse(data, out num);
            if (!bIsValidNumber)
            {
                PrintMessage("please enter a valid number", 2);
                num = 0;
                return false;
            }
            return true;
        } 
        #endregion
        static void Main(string[] args)
        {
            // welcome user
            PrintMessage("Welcome to football application");

            List<Team> lstTeams = new List<Team>();
            char loopIndex = 'a';
            // loop over number of teams
            while(loopIndex!='e')
            {
                // intilize values
                Team myTeam;
                myTeam.NumberOfWins = 0;
                myTeam.NumberOfDraws = 0;
                myTeam.NumberOfLoses = 0;

                // read team information
                PrintMessage("please enter team name");
                myTeam.TeamName = Console.ReadLine();

                PrintMessage("please enter number of wins");
                if (!CheckNumber(Console.ReadLine(), out myTeam.NumberOfWins))
                    continue;

                PrintMessage("please enter number of draws");
                if (!CheckNumber(Console.ReadLine(), out myTeam.NumberOfDraws))
                    continue;

                PrintMessage("please enter number of loses");
                if (!CheckNumber(Console.ReadLine(), out myTeam.NumberOfLoses))
                    continue;

                // calculate points
                myTeam.Points = (myTeam.NumberOfWins * 3) + (myTeam.NumberOfDraws * 1);

                // store team data in list
                lstTeams.Add(myTeam);
                PrintMessage("for exisit press e else press any key");
                loopIndex = Convert.ToChar(Console.ReadLine());
            }

            int maxPoints = lstTeams.Max(x => x.Points);
            Team winner = lstTeams.Where(a => a.Points == maxPoints).FirstOrDefault();
            List<Team> lstFilterTeam = lstTeams.Where(a => a.Points > 20).ToList();
            lstTeams.FirstOrDefault();
            lstTeams.LastOrDefault();

            // sort for teams 

            // print team by winner
            Console.WriteLine("winner is :"+ winner.TeamName);
        }
    }
}
