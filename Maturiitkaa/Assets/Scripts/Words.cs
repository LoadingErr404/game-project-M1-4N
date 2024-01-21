using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words
{
    private readonly string _myWord;
    private readonly int _damage;

    public Words()
    {
        _myWord = "";
        _damage = 0;
    }

    public Words(string word, int damage)
    {
        _myWord = word;
        _damage = damage;
    }

    public override string ToString()
    {
        return _myWord + ":" + _damage + "\n";
    }
}
