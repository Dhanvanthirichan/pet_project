
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
    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.WriteLine("Pet is resting as you have not selected any option");
        pet.rest();
        continue;
    }
    if ( (int.TryParse(choice, out _) || Convert.ToInt32(choice) < 1 || Convert.ToInt32(choice) > 4) != true)  
    {
        Console.WriteLine("Invalid choice");
        Console.WriteLine("Pet is resting as you have selected invalid option");
        pet.rest();
        continue;
    }


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
    public int hunger = 0;
    public int health = 100;
    public int happiness = 100;

    
    void update_status(int hunger=0, int health=0, int happiness=0){
        this.hunger = hunger >= 0 ? (hunger <= 100 ? hunger : 100) : 0;
        this.health = health >= 0 ? (health <= 100 ? health : 100) : 0;
        this.happiness = happiness >= 0 ? (happiness <= 100 ? happiness : 100) : 0;
    }

    public void feed(){
        
        update_status(hunger: hunger - 10, health: health + 5, happiness: happiness) ;
        Console.WriteLine("Your Feeding " + name);
        display_info();
        check_status();
        time_pass();

    }
    public void play(){
        if (check_neglect()){
            neglect();
            Console.WriteLine("Your  cant play with " + name + " as he is not happy with you. Please feed the good boy first.");
        }
        else{
            Console.WriteLine("Your playing with " + name);
            update_status(hunger: hunger + 5, health: health, happiness: happiness + 10);

        }
        display_info();
        check_status();
        time_pass();
    }
    public void rest(){
        update_status(hunger: hunger, health: health +10, happiness: happiness - 5);
        Console.WriteLine("Your pet is resting " + name);
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
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
        }
    }

    public void time_pass(){
        update_status(hunger: hunger+10, health: health, happiness: happiness - 5);
        check_status();
    }

    public bool check_neglect(){
        if (hunger >=50 || happiness <= 40){
            return true;
        }
        return false;
    }
    public void neglect(){
        update_status(hunger: hunger , health: health - 10, happiness: happiness );
    }

}




