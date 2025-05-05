import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { OptimalClassComponent } from './pages/optimal-class/optimal-class.component';
import { BossComponent } from './pages/boss/boss.component';
import { FirearmsComponent } from './pages/firearms/firearms.component';
import { TricksterWeaponsComponent } from './pages/trickster-weapons/trickster-weapons.component';

export const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'optimal-class',
    component: OptimalClassComponent,
  },
  {
    path: 'bosses',
    component: BossComponent,
  },
  {
    path: 'firearms',
    component: FirearmsComponent,
  },
  {
    path: 'trickster-weapons',
    component: TricksterWeaponsComponent,
  },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', redirectTo: 'home' },
];
