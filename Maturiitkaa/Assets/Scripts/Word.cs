using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    private readonly string _myWord;
    private readonly int _damage;

    public Word()
    {
        _myWord = "";
        _damage = 0;
    }

    public Word(string word, int damage)
    {
        _myWord = word;
        _damage = damage;
    }

    public override string ToString()
    {
        return _myWord + ":" + _damage + "\n";
    }
}
