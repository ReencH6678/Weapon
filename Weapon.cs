using System;

class Weapon
{
    public Weapon(int damage, int bullets)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException();

        if (bullets < 0)
            throw new ArgumentOutOfRangeException();

        Damage = damage;
        Bullets = bullets;
    }

    public int Damage { get; private set; }
    public int Bullets { get; private set; }

    public void Fire(Player player)
    {
        if (Bullets <= 0)
            throw new ArgumentOutOfRangeException();

        Bullets--;
        player.TakeDamage(Damage);
    }
}

class Player
{
    private int _health;

    public Player(int health)
    {
        if (_health <= 0)
            throw new ArgumentOutOfRangeException();

        _health = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException();

        _health -= damage;
    }
}

class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new ArgumentNullException();

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException();

        _weapon.Fire(player);
    }
}