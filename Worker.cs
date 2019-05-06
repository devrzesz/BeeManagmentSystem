using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagmentSystem
{
    class Worker
    {
        public Worker(string[] jobs)
        {
            this.jobsICanDo = jobs;
        }

        public int ShiftLeft { get { return shiftsToWork - shiftWorked; } }

        private string currentJob = "";
        public string CurrentJob { get => currentJob; }

        string[] jobsICanDo;

        int shiftsToWork;
        int shiftWorked;


        public bool DoThisJob(string jobToDo, int shiftsToWork)
        {
            if (!String.IsNullOrEmpty(currentJob))
                return false;

            for (int i = 0; i < jobsICanDo.Length; i++)
            {
                if (jobsICanDo[i] == jobToDo)
                {
                    this.shiftsToWork = shiftsToWork;
                    currentJob = jobToDo;
                    shiftWorked = 0;
                    return true;
                }
            }

            return false;

        }

        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;

            shiftWorked++;
            if (shiftWorked > shiftsToWork)
            {
                shiftWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            else
                return false;

        }
    }
}
