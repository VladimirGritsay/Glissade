import { ModelsModule } from './../models/models-module.module';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ViewimageComponent } from './components/viewimage/viewimage.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { StartpageComponent } from './components/startpage-component/startpage-component.component';

@NgModule({
  exports: [
    StartpageComponent, 
  ],

  declarations: [
    ViewimageComponent,
    NotFoundComponent, 
    StartpageComponent,
  ],

  imports: [
    ModelsModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],

  providers: [],
})
export class UiModule {

}