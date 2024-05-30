
Pet pet = new();

Console.WriteLine("Welocme to pet app ");
Console.WriteLine("Enter the name of the pet");
pet.name = Console.ReadLine() ?? "";
Console.WriteLine("Enter the type of the pet");
pet.type = Console.ReadLine() ?? "" ;
Console.WriteLine("Welocme " + pet.name + "the" + pet.type + "!");
while(true){
    Console.WriteLine("What you want to do with yopur pet?");
    Console.WriteLine("1. Feed");
    Console.WriteLine("2. Play");
    Console.WriteLine("3. Rest");
    Console.WriteLine("4. Exit");
    string  choice = Console.ReadLine() ?? "";

    int choice_int = Convert.ToInt32(choice);


    switch (choice_int){
        case 1:
            pet.feed();
            break;
        case 2:
            pet.play();
            break;
        case 3:
            pet.rest();
            break;
        case 4:
            Console.WriteLine("Goodbye");
            return;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}


class Pet
{
    public string name = "";
    public string type = "";
    public int hunger = 50;
    public int health = 50;
    public int happiness = 30;

    public void feed(){
        hunger -= 10;
        health += 5;
        Console.WriteLine("Your Feeding " + name);
        display_info();
        check_status();
        time_pass();

    }
    public void play(){
        happiness += 10;
        hunger += 5;
        Console.WriteLine("Your playing with " + name);
        display_info();
        check_status();
        time_pass();

    }
    public void rest(){
        health += 10;
        happiness -= 5;
        Console.WriteLine("Your pet is resting" + name);
        display_info();
        check_status();
        time_pass();
    }
    public void display_info(){
        Console.WriteLine("The pets name is " + name);
        Console.WriteLine("The pets type is " + type);
        Console.WriteLine("The pets hunger is " + hunger);
        Console.WriteLine("The pets health is " + health);
        Console.WriteLine("The pets happiness is " + happiness);
        }

    public void check_status(){
        if (happiness <= 20 || hunger >= 70 || health <= 20){
            Console.WriteLine("Your pet is not doing well");
        }
        if (happiness <= 0 || hunger >= 100 || health <= 0){
            Console.WriteLine("Your pet has died");
            Environment.Exit(0);
        }
    }

    public void time_pass(){
        hunger += 10;
        happiness -= 5;
        check_status();
    }

}




