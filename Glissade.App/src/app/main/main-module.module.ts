import { NgModule } from '@angular/core';
import { MainComponent } from './components/roote-component/main-component.component';
import { BrowserModule } from '@angular/platform-browser';
import { UiModule } from '../ui/ui-module.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule, Routes } from '@angular/router';
import { ViewimageComponent } from '../ui/components/viewimage/viewimage.component';
import { NotFoundComponent } from '../ui/components/not-found/not-found.component';
import { StartpageComponent } from '../ui/components/startpage-component/startpage-component.component';

const mainRoute: Routes = [
  { path: '', component: StartpageComponent },
  { path: 'viewimage/:id', component: ViewimageComponent },
  { path: '**', component: NotFoundComponent }

];
const annotation = {
  declarations: [MainComponent],
  imports: [
    RouterModule.forRoot(mainRoute),
    BrowserModule,
    UiModule,
    NgbModule.forRoot(),
  ],
  providers: [], 
  bootstrap: [MainComponent] 
}

@NgModule(annotation)
export class MainModule {



}