import { NgModule } from '@angular/core';

import { ComputerService } from './services/comservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchComputerComponent } from './components/fetchcomputer/fetchcomputer.component'
import { createcomputer } from './components/addcomputer/addComputer.component'



@NgModule({

    declarations: [

        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchComputerComponent,
        createcomputer,
    ],

    imports: [

        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([

            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-computer', component: FetchComputerComponent },
            { path: 'register-computer', component: createcomputer },
            { path: 'computer/edit/:id', component: createcomputer },
            { path: '**', redirectTo: 'home' }

        ])

    ],

    providers: [ComputerService]

})

export class AppModuleShared {

}