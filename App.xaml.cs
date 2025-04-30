﻿namespace glopezS5A
{
    public partial class App : Application
    {
        public static Repository.PersonRepository personRepo {  get; set; }
        public App(Repository.PersonRepository personRepository)
        {
            InitializeComponent();
            personRepo = personRepository;
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vHome());
        }
    }
}