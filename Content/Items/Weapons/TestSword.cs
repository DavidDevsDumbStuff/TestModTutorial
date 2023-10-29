using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Content.Projectiles;

namespace TestMod.Content.Items.Weapons
{
    public class TestSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 27;
            Item.knockBack = 6;
            Item.crit = 6;

            Item.value = Item.buyPrice(gold: 10, silver: 50);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;

            Item.shoot = ModContent.ProjectileType<TestSwordProjectile>();
            Item.shootSpeed = 8;
        }

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			// Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
			// 60 frames = 1 second
			target.AddBuff(BuffID.Frostburn2, 360);
		}
    }
}
