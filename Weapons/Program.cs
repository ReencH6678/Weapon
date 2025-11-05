using System;

class Weapon
{
    public Weapon(int damage, int bullets)
    {
        Damage = damage;
        Bullets = bullets;
    }

    public int Damage { get; private set; }
    public int Bullets { get; private set; }

    public void Fire(Player player)
    {
        if (Bullets <= 0)
            throw new InvalidOperationException();

            Bullets--;
            player.TakeDamage(Damage);
        
    }
}

class Player
{
    private int _health;

    public Player(int health)
    {
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
        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException();

        _weapon.Fire(player);
    }
}