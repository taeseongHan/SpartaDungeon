// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;


internal class Program
{
    private static Character player;
    private static Armors armors;   //통신방식 고민
    private static Weapons weapons;
     

    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {

        
        // 캐릭터 정보 세팅
        player = new Character("태송태송", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅
        List<Item> itemList = new List<Item>();

        // Weapons 추가
        Weapons sword1 = new Weapons("낡은검", "2", "쉽게 볼 수 있는 낡은 검 입니다.") ;
        itemList.Add(sword1);

        // Armors 추가
        Armors chestplate1 = new Armors("무쇠갑옷", "5", "무쇠로 만들어져 튼튼한 갑옷입니다.");
        itemList.Add(chestplate1);


        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            if (item == armors)
            {
                Console.WriteLine($"- {armors.Name}    | 방어력:+{armors.DefensePower} | {armors.Description}");
            }
            else if(item == weapons)
            {
                Console.WriteLine($"- {weapons.Name}    | 공격력:+{weapons.OffensePower} | {weapons.Description}");
            }
        }
        
    }


    static void DisplayGameIntro() //게임시작화면
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요. ");
        Console.Write(">> ");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
        }
    }

    static void DisplayMyInfo() //상태보기
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        Console.WriteLine($"공격력 :{player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
        Console.WriteLine($"체력 : {player.Hp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine("원하시는 행동을 입력해주세요  ");
        Console.Write(">> ");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static void DisplayInventory() //인벤토리
    {
        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine(itemList[0]);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                Installation();
                break;
        }

    }
    static void Installation() //장착관리
    {
        Console.Clear();

        Console.WriteLine("인벤토리 - 장착 관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        int input = CheckValidInput(0 , 2);
        
      
    }

    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}
public class Character
{
    public string Name { get; set; }
    public string Job { get; set; }
    public int Level { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Gold { get; set; }

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }
   
}

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
public class Weapons : Item
{
    public string OffensePower { get; set; }

    public Weapons(string weaponName, string offensePower, string weaponInfo)
        : base(weaponName, weaponInfo)
    {
        OffensePower = offensePower;
    }
}

public class Armors : Item
{
    public string DefensePower { get; set; }

    public Armors(string armorName, string defensePower, string armorInfo)
        : base(armorName, armorInfo)
    {
        DefensePower = defensePower;
    }
}



