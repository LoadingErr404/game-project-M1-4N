
public class Word
{
    public readonly string MyWord;
    public readonly int Damage;

    public Word()
    {
        MyWord = "";
        Damage = 0;
    }

    public Word(string word, int damage)
    {
        MyWord = word;
        Damage = damage;
    }
    

    public override string ToString()
    {
        return MyWord + ":" + Damage + "\n";
    }
}
