import { WeaponAttack } from './weapon-attack.model';

export interface TricksterWeapon {
  id: number;
  name: string;
  physicalAttack: number;
  bloodAttack: number;
  arcaneAttack: number;
  fireAttack: number;
  boltAttack: number;
  bulletUse: number;
  rapidPoison: number;
  imprintsNormal: number;
  imprintsUncanny: number;
  imprintsLost: number;
  rally: number;
  strengthRequirement: number;
  skillRequirement: number;
  bloodtingeRequirement: number;
  arcaneRequirement: number;
  maxUpgradeAttack: number;
  attacks: WeaponAttack[];
}
