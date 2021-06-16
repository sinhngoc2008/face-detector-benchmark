# -*- mode: python -*-

block_cipher = None


a = Analysis(['webcam.py'],
             pathex=['C:\\Users\\user\\Dataset\\wider_face_yolo\\benchmark\\tester'],
             binaries=[],
             datas=[('models/ssd/frozen_inference_graph_face.pb', '.')],
             hiddenimports=[],
             hookspath=['hooks'],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher,
             noarchive=False)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          [],
          name='webcam',
          debug=False,
          bootloader_ignore_signals=False,
          strip=False,
          upx=True,
          runtime_tmpdir=None,
          console=True )
