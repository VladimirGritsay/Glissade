import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModuleModule } from './ui/ui-module.module';
 
@NgModule({
  declarations: [
    AppComponent,
     
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiModuleModule,
    
     
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
