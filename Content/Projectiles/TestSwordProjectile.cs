using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Projectiles
{
    public class TestSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 720;
            Projectile.light = 0.1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            Projectile.rotation += 0.2f * Projectile.direction;
            if (Projectile.ai[0] % 5 == 0 && Projectile.ai[0] < 201)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.CursedFlameFriendly, 20, 7);
            }
            if (Projectile.ai[0] >= 201)
            {
                Projectile.ai[0] = 201;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.4f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 600);
        }
    }
}
