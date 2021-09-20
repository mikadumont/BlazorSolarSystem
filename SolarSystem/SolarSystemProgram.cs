using System;
using System.Collections.Generic;
using System.Text;
using SolarSystem.Galaxy;

namespace SolarSystem
{
    public class SolarSystemProgram
    {
        public SolarSystemProgram()
        {
            Moon moon1 = new Moon();
            Sun sun1 = new Sun();
            Stars stars = new Stars();
            Earth earth = new Earth();

            int month = 0;

            // The Unix epoch (or Unix time or POSIX time or Unix timestamp) 
            // is the number of seconds that have elapsed since January 1, 1970
            var computerTime = Math.Round((DateTime.Now.Subtract(new System.DateTime(1970, 1, 1))).TotalDays / 365);

            for (long year = 0; year < computerTime; year++)
            {
                // Earth completes it's orbit once a year
                Planet.CompletedRotation();

                // lunar eclipse 0-3 times per year
                for (int day = 0; day < 365; day++)
                {
                    // Earth completing 1 rotation creates 1 day
                    Planet.CompletedRotation();

                    // The moon pulls tides every day
                    Moon.PullTides();
                    if (day % 30 == 0)
                    {
                        // The moon completes it's orbit and a full rotation once a month
                        Moon.CompletedOrbit();
                        Moon.CompletedRotation();
                        month++;

                    }

                    // The moon wanes and waxes mid-way
                    if (day % 15 == 0)
                    {
                        moon1.waning = !moon1.waning;
                        moon1.waxing = !moon1.waxing;
                    }
                }
            }
        }

        public static bool IsLeapYear(int leapYear)
        {
            return (leapYear) % 4 == 0;
        }

    }
}
