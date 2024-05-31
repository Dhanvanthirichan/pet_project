
Pet pet = new();

Console.WriteLine("Welocme to pet app ");
pet.type = string.Empty;
while(string.IsNullOrWhiteSpace(pet.type)){
Console.WriteLine("Choose the type of pet you want to have");
Console.WriteLine("1. Dog");
Console.WriteLine("2. Cat");
Console.WriteLine("3. Tiger");
Console.WriteLine("4. Alligator");
Console.WriteLine("5. Blue Whale");
string pet_choice = Console.ReadLine() ?? "";
if (string.IsNullOrWhiteSpace(pet_choice))
{
    Console.WriteLine("You have not selected any pet type");
    continue;
}
if ( (int.TryParse(pet_choice, out _) || Convert.ToInt32(pet_choice) < 1 || Convert.ToInt32(pet_choice) > 6) != true)  
{
    Console.WriteLine("Invalid choice");
    Console.WriteLine("You have selected invalid pet type");
    continue;
}
int pet_choice_int = Convert.ToInt32(pet_choice);
switch (pet_choice_int){
    case 1:
        pet.type = "Dog";
        break;
    case 2:
        pet.type = "Cat";
        break;
    case 3:
        pet.type = "Tiger";
        break;
    case 4:
        pet.type = "Alligator";
        break;
    case 5:
        pet.type = "Blue Whale";
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}
}
Console.WriteLine("Enter the name of the pet");
pet.name = Console.ReadLine() ?? "";
if (string.IsNullOrWhiteSpace(pet.name))
{
    Console.WriteLine("You have not entered any name for the pet defaulting to progrmmer's choice of his pet name");
    pet.name = "Trevor";
}

Console.WriteLine("Welocme " + pet.name + "the" + pet.type + "!");
while(true){
    Console.WriteLine("What you want to do with yopur pet?");
    Console.WriteLine("1. Feed");
    Console.WriteLine("2. Play");
    Console.WriteLine("3. Rest");
    Console.WriteLine("4. Dipaly pet stats");
    Console.WriteLine("5. Exit");
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
            pet.display_info();
            break;
        case 5:
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
    public double hunger = 0;
    public double health = 10;
    public double happiness = 10;

    
    void update_status(double hunger=0, double health=0, double happiness=0){
        this.hunger = Math.Clamp(hunger, 0, 10);
        this.health = Math.Clamp(health, 0, 10);
        this.happiness = Math.Clamp(happiness, 0, 10);
        this.hunger = Math.Round(this.hunger, 1);
        this.health = Math.Round(this.health, 1);
        this.happiness = Math.Round(this.happiness, 1);

    }

    public void feed(){
        
        update_status(hunger: hunger - 1, health: health + 0.5, happiness: happiness + 0.5) ;
        Console.WriteLine("Your Feeding " + name);
        Console.WriteLine("Your pet is less hungry " + hunger + " and more healthy " + health + " and happy " + happiness);
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
            update_status(hunger: hunger + 0.5, health: health, happiness: happiness + 1);
            Console.WriteLine("Your pet is more happy " + happiness + " and hungry " + hunger);

        }
        check_status();
        time_pass();
    }
    public void rest(){
        update_status(hunger: hunger, health: health +1, happiness: happiness - 0.5);
        Console.WriteLine("Your pet is resting " + name);
        Console.WriteLine("Your pet is more he6althy " + health + " and less happy " + happiness);
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
        if (happiness <= 2 || hunger >= 7 || health <= 2){
            Console.WriteLine("Your pet is not doing well");
        }
        if (happiness <= 0 || hunger >= 10 || health <= 0){
            Console.WriteLine("Your pet has died");
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
        }
    }

    public void time_pass(){
        Console.WriteLine("Time is passing");
        update_status(hunger: hunger+0.7, health: health, happiness: happiness - 0.5);
        Console.WriteLine("Your pet is getting hungry " +hunger+  " and less happy " + happiness);
        check_status();
    }

    public bool check_neglect(){
        if (hunger >=5 || happiness <= 4){
            return true;
        }
        return false;
    }
    public void neglect(){
        update_status(hunger: hunger , health: health - 1, happiness: happiness );
    }

}




