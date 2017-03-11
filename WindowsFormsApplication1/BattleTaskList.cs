namespace BattleTaskListNameSpace
{
    class BattleTaskList
    {
        public struct BattletasklistStruct
        {
            private string taskname;
            public string TaskName
            {
                get { return taskname; }
                set { taskname = value; }
            }

            private int tasktime;
            public int TaskNumber
            {
                get { return tasktime; }
                set { tasktime = value; }
            }

            private string taskmianteam;
            public string TaskMianTeam
            {
                get { return taskmianteam; }
                set { taskmianteam = value; }
            }

            private string tasksupportteam;
            public string TaskSupportTeam
            {
                get { return tasksupportteam; }
                set { tasksupportteam = value; }
            }

            private bool choicetofix;
            public bool ChoinceToFix
            {
                get { return choicetofix; }
                set { choicetofix = value; }
            }

            private int fixmaxtime;
            public int FixMaxTime
            {
                get { return fixmaxtime; }
                set { fixmaxtime = value; }
            }

            private int fixmintime;
            public int FixMintime
            {
                get { return fixmintime; }
                set { fixmintime = value; }
            }

            //有参数构造函数
            public void Battletasklist(string _taskname, int _tasktime, string _taskmianteam, string _tasksupportteam, bool _choicetofix, int _fixmaxtime, int _fixmintime)
            {
                //如果要在结构中使用构造函数则必须给所有的变量赋值（在构造函数中赋值）
                this.taskname = _taskname;
                this.tasktime = _tasktime;
                this.taskmianteam = _taskmianteam;
                this.tasksupportteam = _tasksupportteam;
                this.choicetofix = _choicetofix;
                this.fixmaxtime = _fixmaxtime;
                this.fixmintime = _fixmintime;

            }
        }
    }
}
