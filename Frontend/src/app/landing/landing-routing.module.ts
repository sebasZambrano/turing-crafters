import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Component Pages
import { JobComponent } from './job/job.component';
import { CoverComponent } from '../account/auth/signin/cover/cover.component';

const routes: Routes = [
	{
		path: '',
		component: CoverComponent,
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class LandingRoutingModule {}
