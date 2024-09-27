namespace _26TextRPG.Main
{
    public class CreateAcc
    {
        public string nickName { get; set; }
        public void CreateNickname()
        {
            Console.WriteLine("게임에 처음 접속하셨습니다.");
            Console.WriteLine("원하는 닉네임을 입력해주세요.");
            string nickName = Console.ReadLine();
        }
    }
}