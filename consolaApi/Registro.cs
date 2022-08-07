using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace consolaApi
{
    public class Registro
    {
            public string instance_id { get; set; }
            public int count { get; set; }
            public string etag { get; set; }
            public Task[] tasks { get; set; }
        }

        public class Task
        {
            public string fleet { get; set; }
            public string log { get; set; }
            public Custom_Fields custom_fields { get; set; }
            public long created_at { get; set; }
            public int task_id { get; set; }
            public Archive archive { get; set; }
            public string type { get; set; }
            public int priority { get; set; }
            public string created_by { get; set; }
            public Steps steps { get; set; }
            public Equipment[] equipments { get; set; }
            public long updated_at { get; set; }
            public long last_transition_at { get; set; }
            public Report report { get; set; }
            public Client client { get; set; }
            public string etag { get; set; }
            public string state { get; set; }
            public string created_in { get; set; }
            public bool rejectable { get; set; }
            public object issue { get; set; }
            public string description { get; set; }
            public int duration { get; set; }
            public Sign sign { get; set; }
            public string token { get; set; }
            public long start_time { get; set; }
            public string assigned_to { get; set; }
            public Validation validation { get; set; }
        }

        public class Custom_Fields
        {
            public long created_from_app_at { get; set; }
        }

        public class Archive
        {
            public string archived_reason { get; set; }
            public string archived_by { get; set; }
            public string archived_state { get; set; }
            public bool is_archived { get; set; }
            public long archived_at { get; set; }
        }

        public class Steps
        {
            public string log { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public Field[] fields { get; set; }
        }

        public class Field
        {
            public string fleet { get; set; }
            public string name { get; set; }
            public int index { get; set; }
            public string description { get; set; }
            public string etag { get; set; }
            public bool mandatory { get; set; }
            public long done_at { get; set; }
            public string comment { get; set; }
        }

        public class Report
        {
            public string fleet { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public Group[] groups { get; set; }
            public string log { get; set; }
        }

        public class Group
        {
            public bool _public { get; set; }
            public string name { get; set; }
            public bool can_repeat { get; set; }
            public int index { get; set; }
            public Field1[] fields { get; set; }
            public bool is_copy { get; set; }
        }

        public class Field1
        {
            public bool _private { get; set; }
            public string possible_values { get; set; }
            public string name { get; set; }
            public bool can_repeat { get; set; }
            public string description { get; set; }
            public int index { get; set; }
            public string type { get; set; }
            public bool comment_enabled { get; set; }
            public bool mandatory { get; set; }
            public bool is_copy { get; set; }
            public string fleet { get; set; }
            public string task_id { get; set; }
            public string etag { get; set; }
            public string value { get; set; }
            public string comment { get; set; }
        }

        public class Client
        {
            public string rut { get; set; }
            public Address address { get; set; }
            public Contact contact { get; set; }
            public string name { get; set; }
        }

        public class Address
        {
            public string reference { get; set; }
            public int number { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public string street { get; set; }
            public float latitude { get; set; }
            public string raw_address { get; set; }
            public float longitude { get; set; }
            public string commune { get; set; }
            public string type { get; set; }
            public string apartment { get; set; }
        }

        public class Contact
        {
            public string phone { get; set; }
            public string name { get; set; }
            public string email { get; set; }
        }

        public class Sign
        {
            public Client1 client { get; set; }
            public Worker worker { get; set; }
        }

        public class Client1
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

        public class Validation
        {
            public string validated_by { get; set; }
            public bool is_valid { get; set; }
            public string validated_reason { get; set; }
            public long validated_at { get; set; }
        }

        public class Equipment
        {
            public string internal_id { get; set; }
        }

    }

