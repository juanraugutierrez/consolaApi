using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolaApi
{
 
        public class Rootobject
        {
            public Task task { get; set; }
            public string instance_id { get; set; }
            public string etag { get; set; }
        }

        public class Task
        {
            public string fleet { get; set; }
            public Issue[] issue { get; set; }
            public string log { get; set; }
            public Custom_Fields custom_fields { get; set; }
            public Sign sign { get; set; }
            public long created_at { get; set; }
            public string description { get; set; }
            public int task_id { get; set; }
            public string type { get; set; }
            public int priority { get; set; }
            public string created_by { get; set; }
            public string token { get; set; }
            public int duration { get; set; }
            public long start_time { get; set; }
            public long updated_at { get; set; }
            public long last_transition_at { get; set; }
            public Report report { get; set; }
            public Client1 client { get; set; }
            public string etag { get; set; }
            public string state { get; set; }
            public string created_in { get; set; }
            public string assigned_to { get; set; }
            public bool rejectable { get; set; }
        }

        public class Custom_Fields
        {
            public long created_from_app_at { get; set; }
        }

        public class Sign
        {
            public Client client { get; set; }
            public Worker worker { get; set; }
        }

        public class Client
        {
            public string rut { get; set; }
            public string image { get; set; }
            public string custom_message { get; set; }
            public string name { get; set; }
        }

        public class Worker
        {
            public string rut { get; set; }
            public string image { get; set; }
            public string custom_message { get; set; }
            public string name { get; set; }
        }

        public class Report
        {
            public string fleet { get; set; }
            public string log { get; set; }
            public string name { get; set; }
            public Group[] groups { get; set; }
        }

        public class Group
        {
            public string name { get; set; }
            public int index { get; set; }
            public Field[] fields { get; set; }
        }

        public class Field
        {
            public string fleet { get; set; }
            public bool _private { get; set; }
            public string name { get; set; }
            public bool can_repeat { get; set; }
            public int index { get; set; }
            public string etag { get; set; }
            public string task_id { get; set; }
            public string type { get; set; }
            public bool mandatory { get; set; }
            public bool comment_enabled { get; set; }
            public string value { get; set; }
            public bool is_copy { get; set; }
            public string possible_values { get; set; }
        }

        public class Client1
        {
            public string rut { get; set; }
            public Contact contact { get; set; }
            public string name { get; set; }
        }

        public class Contact
        {
            public string phone { get; set; }
            public string name { get; set; }
            public string email { get; set; }
        }

        public class Issue
        {
            public string question { get; set; }
            public string name { get; set; }
            public string caption { get; set; }
            public int index { get; set; }
        }

    }

