<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title>Quasar with SignalR</q-toolbar-title>

        <div>Quasar v{{ $q.version }}</div>
      </q-toolbar>
    </q-header>

    <q-drawer v-model="leftDrawerOpen" show-if-above bordered content-class="bg-grey-1">
      <q-list>
        <q-item-label header class="text-grey-8">Essential Links</q-item-label>
        <EssentialLink v-for="link in essentialLinks" :key="link.title" v-bind="link" />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import EssentialLink from 'components/EssentialLink.vue'

const linksData = [
  {
    title: 'Docs',
    caption: 'quasar.dev',
    icon: 'school',
    link: 'https://quasar.dev'
  },
  {
    title: 'SignalR',
    caption: 'Real-Time',
    icon: 'code',
    link: 'https://dotnet.microsoft.com/apps/aspnet/signalr'
  },
  {
    title: 'SignalR History',
    caption: 'chat.quasar.dev',
    icon: 'chat',
    link: 'https://www.codemag.com/article/1807061/Build-Real-time-Applications-with-ASP.NET-Core-SignalR'
  },
  {
    title: 'YouTube Video',
    caption: 'forum.quasar.dev',
    icon: 'video',
    link: 'https://www.youtube.com/watch?v=YwezzKWrFuo'
  },
  {
    title: 'About Me',
    caption: '',
    icon: 'favorite',
    link: 'https://www.aksel.com'
  }
];

export default {
  name: 'MainLayout',
  components: { EssentialLink },
  data () {
    return {
      leftDrawerOpen: false,
      essentialLinks: linksData
    }
  }
}
</script>
