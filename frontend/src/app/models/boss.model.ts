export interface Boss {
  id: number;
  name: string;
  health: number;
  bloodEchoes: number;
  isInterruptible: boolean;
  isRequired: boolean;
  isBeast: boolean;
  isKin: boolean;
  isWeakToSerrated: boolean;
  isWeakToRighteous: boolean;
  physicalDefense: number;
  bluntDefense: number;
  thrustDefense: number;
  bloodtingeDefense: number;
  arcaneDefense: number;
  fireDefense: number;
  boltDefense: number;
  slowPoisonResistance: number;
  rapidPoisonResistance: number;
  imageUrl: string;
}
