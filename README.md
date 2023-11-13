# SpartaDungeon
혼자 개인과제 샘플 코드로 내 생각대로 만들어본 코드


internal class Program
{
    private static Character player;
    private static Weapons weapon;
    private static Armors armor;

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
        weapon = new Weapons("낡은 검", "공격력", "쉽게 볼 수 있는 낡은 검 입니다.");
        armor = new Armors("무쇠갑옷", "방어력", "무쇠로 만들어져 튼튼한 갑옷입니다." );
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
        Console.WriteLine($"- {armor.ArmorName}    | {armor.DefensePower} +5 |{armor.ArmorInfo}");
        Console.WriteLine($"- {weapon.WeaponName}    | {weapon.OffensePower} +2 |{weapon.WeaponInfo}");
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
        Console.WriteLine($"- 1. {armor.ArmorName}    | {armor.DefensePower} +5 |{armor.ArmorInfo}");
        Console.WriteLine($"- 2. {weapon.WeaponName}    | {weapon.OffensePower} +2 |{weapon.WeaponInfo}");
        Console.WriteLine();
        
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        int input = CheckValidInput(0 , 2);
        
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;

            case 1:
                if (armor.ArmorName == "무쇠갑옷")
                {
                    armor.ArmorName = "[E]무쇠갑옷";
                }
                else
                {
                    armor.ArmorName = "무쇠갑옷";
                }
                Installation();
                break;
                
                
        }
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
public class Weapons
{
    public string WeaponName { get; set; }
    public string OffensePower { get; set; }
    public string WeaponInfo { get; set; }

    public Weapons(string weaponname, string offensepower, string weaponinfo)
    {
        WeaponName = weaponname;
        OffensePower = offensepower;
        WeaponInfo = weaponinfo;

    }

  
}

public class Armors
{
    public string ArmorName { get; set; }
    public string DefensePower { get; set; }
    public string ArmorInfo { get; set; }

    public Armors(string amorname, string amorpower, string amorinfo)
    {
        ArmorName = amorname;
        DefensePower = amorpower;
        ArmorInfo = amorinfo;

    }
}
    
    
    이걸 가지고 튜터님께 질문하러 갔었는데 
    1. 아이템 정보를 클래스 / 구조체로 활용해 보기
    2. 아이템 정보를 배열로 관리하기
    이걸로 한번 고민해서 만들어 보는게 좋겠다고 하셔서 지금 제출한 코드로 바꾸다가 시간이 다되어서 제출함!
    강의 다시 찾아보고 모르는것 구글링이랑 챗gpt 활용하면서 했는데 list쓰는것 클래스 상속시켜주는것 등 제대로 이해하지 못하고 있던부분을 이해하긴함
    근데 아직 구조적인 부분이 헷갈리고 코드를 잘 모르겠음
    해설강의보고 다시 만들어봐야겠음 2주차 3주차 강의 
